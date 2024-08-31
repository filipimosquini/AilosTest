using MediatR;
using Questao5.Application.Commands.Movements.Models;

namespace Questao5.Application.Commands.Movements;

public class CreateMovementCommand : IRequest<CreateMovementCommandResponse>
{
    /// <summary>
    /// The request Id
    /// </summary>
    public string RequestId { get; set; }

    /// <summary>
    /// The bank account number
    /// </summary>
    public int AccountNumber { get; set; }

    /// <summary>
    /// The amount of bank movement
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// The Movement Types.
    /// The accepted values is [C] Credit or [D] Debit
    /// </summary>
    public string MovementType { get; set; }
}