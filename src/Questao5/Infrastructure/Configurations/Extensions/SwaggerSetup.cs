﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Questao5.Infrastructure.Configurations.Extensions;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGenNewtonsoftSupport();
        services.AddSwaggerGen(options =>
        {
            var xmlFilesPath = "./Infrastructure/Configurations/Swagger/Doc";
            var folder = new DirectoryInfo(xmlFilesPath);

            var files = folder.GetFiles("*.xml");

            foreach (var file in files)
            {
                options.IncludeXmlComments(file.FullName, true);
            }

            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Version = "v1",
                Title = "Movements API",
                Description = "API that provides endpoints for movements services.",
                Contact = new OpenApiContact() { Name = "Filipi Mosquini", Email = "mosquinilabs@gmail.com" },
                License = new OpenApiLicense()
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                },
            });
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder builder)
    {
        return builder
            .UseSwagger()
            .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movements API"));
    }
}