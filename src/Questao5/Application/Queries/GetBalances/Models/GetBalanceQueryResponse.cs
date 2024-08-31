using System;

namespace Questao5.Application.Queries.Movements.Models;

public class GetBalanceQueryResponse
{
    public int AccountNumber { get; set; }
    public string Holder { get; set; }
    public DateTime QueryDate { get; set; }
    public double Balance { get; set; }
}