using Questao5.Domain.Services;
using Questao5.Domain.Stores;
using Questao5.Infrastructure.Database.Idempotencies.Models;
using System;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Services.Idempotencies;

public class IdempotencyService : IIdempotencyService
{
    private readonly IIdempotencyQueryStore _idempotencyQueryStore;
    private readonly IIdempotencyCommandStore _idempotencyCommandStore;

    public IdempotencyService(IIdempotencyQueryStore idempotencyQueryStore, IIdempotencyCommandStore idempotencyCommandStore)
    {
        _idempotencyQueryStore = idempotencyQueryStore;
        _idempotencyCommandStore = idempotencyCommandStore;
    }

    public async Task<(bool Created, bool RequestOverwrited, bool HasResponse, string Request, string Response)> CreateIdepotencyAsync(Guid idepotencyToken, string jsonRequest)
    {
        if (string.IsNullOrWhiteSpace(jsonRequest))
        {
            return(false, false, false, jsonRequest, string.Empty);
        }

        var idepotency = await _idempotencyQueryStore.GetIdepotencyAsync(idepotencyToken);

        if (idepotency is null)
        {
            await _idempotencyCommandStore.AddIdepotencyAsync(new CreateIdepotencyRequest
            {
                Id = idepotencyToken,
                Request = jsonRequest
            });

            return (true, false, false, jsonRequest, string.Empty);
        }

        if (idepotency.Request.Equals(jsonRequest, StringComparison.OrdinalIgnoreCase))
        {
            return (false, false, !string.IsNullOrWhiteSpace(idepotency.Response), jsonRequest, idepotency.Response);
        }

        return (false, true, !string.IsNullOrWhiteSpace(idepotency.Response), idepotency.Request, idepotency.Response);
    }

    public async Task UpdateIdepotencyAsync(Guid idepotencyToken, string jsonResponse)
    {
        if (string.IsNullOrWhiteSpace(jsonResponse))
        {
            return;
        }

        var idepotency = await _idempotencyQueryStore.GetIdepotencyAsync(idepotencyToken);

        if (idepotency is null)
        {
            return;
        }

        await _idempotencyCommandStore.UpdateIdepotencyResponse(new UpdateIdepotencyRequest
        {
            Id = idepotencyToken,
            Response = jsonResponse
        });
    }
}