using System;

namespace Questao5.Infrastructure.Database.Movements.Models;

public class CreateMovementRequest
{
    public int AccountNumber { get; set; }

    public DateTime MovimentDate { get; set; }

    public double Amount { get; set; }

    public string MovementType { get; set; }
}