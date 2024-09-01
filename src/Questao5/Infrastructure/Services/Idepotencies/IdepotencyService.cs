using Questao5.Domain.Services;
using Questao5.Domain.Stores;
using Questao5.Infrastructure.Database.Idepotencies.Models;
using System;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Services.Idepotencies;

public class IdepotencyService : IIdepotencyService
{
    private readonly IIdepotencyQueryStore _idepotencyQueryStore;
    private readonly IIdepotencyCommandStore _idepotencyCommandStore;

    public IdepotencyService(IIdepotencyQueryStore idepotencyQueryStore, IIdepotencyCommandStore idepotencyCommandStore)
    {
        _idepotencyQueryStore = idepotencyQueryStore;
        _idepotencyCommandStore = idepotencyCommandStore;
    }

    public async Task<(bool Created, bool RequestOverwrited, bool HasResponse, string Request, string Response)> CreateIdepotencyAsync(Guid idepotencyToken, string jsonRequest)
    {
        if (string.IsNullOrWhiteSpace(jsonRequest))
        {
            return(false, false, false, jsonRequest, string.Empty);
        }

        var idepotency = await _idepotencyQueryStore.GetIdepotencyAsync(idepotencyToken);

        if (idepotency is null)
        {
            await _idepotencyCommandStore.AddIdepotencyAsync(new CreateIdepotencyRequest
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

        var idepotency = await _idepotencyQueryStore.GetIdepotencyAsync(idepotencyToken);

        if (idepotency is null)
        {
            return;
        }

        await _idepotencyCommandStore.UpdateIdepotencyResponse(new UpdateIdepotencyRequest
        {
            Id = idepotencyToken,
            Response = jsonResponse
        });
    }
}