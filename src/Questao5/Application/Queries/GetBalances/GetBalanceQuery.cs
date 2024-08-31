using MediatR;
using Questao5.Application.Queries.Movements.Models;

namespace Questao5.Application.Queries.Movements;

public class GetBalanceQuery : IRequest<GetBalanceQueryResponse>
{
    public int AccountNumber { get; set; }
}