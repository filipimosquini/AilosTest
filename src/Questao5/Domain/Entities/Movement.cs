using Questao5.Domain.Enumerators;
using System;

namespace Questao5.Domain.Entities;

public class Movement
{
    public Guid MovementId { get; set; }

    public int AccountNumber { get; set; }

    public DateTime MovimentDate { get; set; }

    public double Amount { get; set; }

    public MovementTypeEnum MovementType { get; set; }
}