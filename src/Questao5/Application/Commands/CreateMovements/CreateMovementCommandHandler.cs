using MediatR;
using Questao5.Application.Commands.Movements.Models;
using Questao5.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Questao5.Application.Commands.Movements;

public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand, CreateMovementCommandResponse>
{
    private readonly IMovementService _movementService;

    public CreateMovementCommandHandler(IMovementService movementService)
    {
        _movementService = movementService;
    }

    public async Task<CreateMovementCommandResponse> Handle(CreateMovementCommand command, CancellationToken cancellationToken)
    {
        await _movementService.ValidateAccountAsync(command.AccountNumber);

        var movementId = await _movementService.CreateMovementAsync(command);

        return new CreateMovementCommandResponse
        {
            MovementId = movementId
        };
    }
}