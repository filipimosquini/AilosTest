using MediatR;
using Questao5.Application.Commands.Movements.Models;

namespace Questao5.Application.Commands.Movements;

public class CreateMovementCommand : IRequest<CreateMovementCommandResponse>
{
    /// <summary>
    /// The request Id used for idempotency verification.
    /// </summary>
    /// <example>25561a63-fe01-41fb-bb97-87e4a9b64ac1</example>
    public string RequestId { get; set; }

    /// <summary>
    /// The bank account number
    /// </summary>
    /// <example>123</example>
    public int AccountNumber { get; set; }

    /// <summary>
    /// The amount of bank movement
    /// </summary>
    /// <example>300</example>
    public double Amount { get; set; }

    /// <summary>
    /// The Movement Types.
    /// The accepted values is [C] Credit or [D] Debit
    /// </summary>
    /// <example>C</example>
    public string MovementType { get; set; }
}