using System;

namespace Questao5.Application.Commands.Movements.Models;

public class CreateMovementCommandResponse
{
    /// <summary>
    /// The movement id generated after store a bank movement
    /// </summary>
    /// <example>3fa85f64-5717-4562-b3fc-2c963f66afa6</example>
    public Guid MovementId { get; set; }
}