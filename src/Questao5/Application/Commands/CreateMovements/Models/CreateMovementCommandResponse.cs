using System;

namespace Questao5.Application.Commands.Movements.Models;

public class CreateMovementCommandResponse
{
    /// <summary>
    /// The movement id generated after store a bank movement
    /// </summary>
    public Guid MovementId { get; set; }
}