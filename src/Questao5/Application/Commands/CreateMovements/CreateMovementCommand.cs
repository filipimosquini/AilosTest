using MediatR;
using Questao5.Application.Commands.Movements.Models;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands.Movements;

public class CreateMovementCommand : IRequest<CreateMovementCommandResponse>
{
    public string RequestId { get; set; }
    public string AccountId { get; set; }
    public double Amount { get; set; }
    public MovementTypeEnum MovementType { get; set; }
}