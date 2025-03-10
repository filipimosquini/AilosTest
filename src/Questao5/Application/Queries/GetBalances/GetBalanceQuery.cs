﻿using MediatR;
using Questao5.Application.Queries.Movements.Models;

namespace Questao5.Application.Queries.Movements;

public class GetBalanceQuery : IRequest<GetBalanceQueryResponse>
{
    /// <summary>
    /// The bank account number
    /// </summary>
    /// <example>123</example>
    public int AccountNumber { get; set; }
}