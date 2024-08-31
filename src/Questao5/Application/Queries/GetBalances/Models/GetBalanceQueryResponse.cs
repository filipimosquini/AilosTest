using System;

namespace Questao5.Application.Queries.Movements.Models;

public class GetBalanceQueryResponse
{
    /// <summary>
    /// The bank account number
    /// </summary>
    public int AccountNumber { get; set; }

    /// <summary>
    /// The holder of bank account
    /// </summary>
    public string Holder { get; set; }

    /// <summary>
    /// A datetime when query occurs
    /// </summary>
    public DateTime QueryDate { get; set; }

    /// <summary>
    /// The balance of bank movements 
    /// </summary>
    public double Balance { get; set; }
}