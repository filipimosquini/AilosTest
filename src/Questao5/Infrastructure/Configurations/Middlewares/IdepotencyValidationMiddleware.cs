﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Questao5.BuildingBlocks.CrossCutting.Extensions;
using Questao5.Domain.Services;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Configurations.Middlewares;

public class IdepotencyValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IIdepotencyService _idepotencyService;

    public IdepotencyValidationMiddleware(RequestDelegate next, IIdepotencyService idepotencyService)
    {
        _next = next;
        _idepotencyService = idepotencyService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Temporarily replace the HttpResponseStream, which is a write-only stream, with a MemoryStream to capture it's value in-flight.
        var originalResponseBody = context.Response.Body;
        using var newResponseBody = new MemoryStream();
        context.Response.Body = newResponseBody;

        var requestBody = await ReadBodyFromRequestAsync(context.Request);

        if (string.IsNullOrWhiteSpace(requestBody))
        {
            await _next(context);
            return;
        }

        var requestBodyObject = JObject.Parse(requestBody!);

        if (string.IsNullOrWhiteSpace(requestBodyObject["requestId"]?.ToString()))
        {
            await _next(context);
            return;
        }

        if (!Guid.TryParse(requestBodyObject["requestId"]?.ToString(), out _))
        {
            await _next(context);
            return;
        }

        var idepotency = await _idepotencyService.CreateIdepotencyAsync(Guid.Parse(requestBodyObject["requestId"]?.ToString()), requestBody);

        if (!idepotency.Created && idepotency.HasResponse)
        {
            await OverwriteResponseBodyAndReturnByMiddlewareAsync(context, idepotency.Response);
            return;
        }

        if (!idepotency.Created && !idepotency.HasResponse && idepotency.RequestOverwrited)
        {
            await _next(await OverwriteRequestBodyAsync(context, idepotency.Request));
        }

        // Define offset flow position from stream. In this case, define flow to begin
        newResponseBody.Seek(0, SeekOrigin.Begin);

        if (context.Response.StatusCode < StatusCodes.Status400BadRequest)
        {
            await _idepotencyService.UpdateIdepotencyAsync(Guid.Parse(requestBodyObject["requestId"]?.ToString()),
                await ReadBodyFromResponseAsync(context.Response));
        }

        await newResponseBody.CopyToAsync(originalResponseBody);
    }

    public virtual async Task<string?> ReadBodyFromRequestAsync(HttpRequest request)
    {
        // Ensure the request's body can be read multiple times (for the next middlewares in the pipeline).
        request.EnableBuffering();

        using var streamReader = new StreamReader(request.Body, leaveOpen: true);
        var requestBody = await streamReader.ReadToEndAsync();

        // Reset the request's body stream position for next middleware in the pipeline.
        request.Body.Position = 0;

        if (request.ContentType is not null && request.ContentType.Contains("application/json"))
        {
            return Regex.Unescape(requestBody).Replace("\"", "'");
        }

        return requestBody;
    }

    public virtual async Task<string?> ReadBodyFromResponseAsync(HttpResponse response)
    {
        using var streamReader = new StreamReader(response.Body, leaveOpen: true);
        var responseBody = await streamReader.ReadToEndAsync();

        // Reset the response's body stream position for next middleware in the pipeline.
        response.Body.Position = 0;

        if (response.ContentType is not null && response.ContentType.Contains("application/json"))
        {
            return Regex.Unescape(responseBody).Replace("\"", "'");
        }

        return responseBody;
    }

    public virtual async Task<HttpContext> OverwriteRequestBodyAsync(HttpContext context, string requestBody)
    {
        context.Request.Body = await (new StringContent(JsonConvert.SerializeObject(requestBody.FromJson<object>()),
            Encoding.UTF8, "application/json")).ReadAsStreamAsync();

        return context;
    }

    public virtual async Task OverwriteResponseBodyAndReturnByMiddlewareAsync(HttpContext context, string responseBody)
    {
        context.Response.StatusCode = StatusCodes.Status200OK;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(JsonConvert.SerializeObject(responseBody.FromJson<object>()));
    }
}