using System;

namespace Questao5.Application.Queries.Movements.Models;

public class GetBalanceQueryResponse
{
    /// <summary>
    /// The bank account number
    /// </summary>
    /// <example>123</example>
    public int AccountNumber { get; set; }

    /// <summary>
    /// The holder of bank account
    /// </summary>
    /// <example>Katherine Sanchez</example>
    public string Holder { get; set; }

    /// <summary>
    /// A datetime when query occurs
    /// </summary>
    /// <example>2024-09-01T14:38:40.2212991Z</example>
    public DateTime QueryDate { get; set; }

    /// <summary>
    /// The balance of bank movements 
    /// </summary>
    /// <example>1000.50</example> 
    public double Balance { get; set; }
}