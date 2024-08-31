using System;
using MediatR;
using Questao5.Application.Queries.Movements.Models;
using Questao5.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Questao5.Application.Queries.Movements;

public class GetBalanceQueryHandler : IRequestHandler<GetBalanceQuery, GetBalanceQueryResponse>
{
    private readonly IMovementService _movementService;

    public GetBalanceQueryHandler(IMovementService movementService)
    {
        _movementService = movementService;
    }

    public async Task<GetBalanceQueryResponse> Handle(GetBalanceQuery query, CancellationToken cancellationToken)
    {
        var account = await _movementService.ValidateAccountAsync(query.AccountNumber);

        return new GetBalanceQueryResponse
        {
            AccountNumber = account.Number,
            Holder = account.Holder,
            QueryDate = DateTime.UtcNow,
            Balance = await _movementService.GetBalanceAsync(query.AccountNumber)
        };
    }
}