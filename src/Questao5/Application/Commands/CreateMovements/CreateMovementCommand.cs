using MediatR;
using Questao5.Application.Commands.Movements.Models;

namespace Questao5.Application.Commands.Movements;

public class CreateMovementCommand : IRequest<CreateMovementCommandResponse>
{
    public string RequestId { get; set; }
    public int AccountNumber { get; set; }
    public double Amount { get; set; }
    public string MovementType { get; set; }
}