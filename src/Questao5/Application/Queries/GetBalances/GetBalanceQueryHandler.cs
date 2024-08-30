using MediatR;
using Questao5.Application.Queries.Movements.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Questao5.Application.Queries.Movements;

public class GetBalanceQueryHandler : IRequestHandler<GetBalanceQuery, GetBalanceQueryResponse>
{
    public Task<GetBalanceQueryResponse> Handle(GetBalanceQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}