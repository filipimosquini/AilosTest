using System;
using MediatR;
using Questao5.Application.Commands.Movements.Models;
using Questao5.Domain.Stores;
using Questao5.Infrastructure.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Questao5.Infrastructure.Database.Movements.Models;

namespace Questao5.Application.Commands.Movements;

public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand, CreateMovementCommandResponse>
{
    private readonly IMovementQueryStore _movementQueryStore;
    private readonly IMovementCommandStore _movementCommandStore;

    public CreateMovementCommandHandler(IMovementQueryStore movementQueryStore, IMovementCommandStore movementCommandStore)
    {
        _movementQueryStore = movementQueryStore;
        _movementCommandStore = movementCommandStore;
    }

    public async Task<CreateMovementCommandResponse> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
    {
        var account = await _movementQueryStore.GetAccountAsync(request.AccountNumber);

        if (account is null)
        {
            throw new AccountNotFoundException();
        }

        if (!account.Active)
        {
            throw new AccountInactiveException();
        }

        var movementId = await _movementCommandStore.AddMovementAsync(new CreateMovementRequest()
        {
            AccountNumber = request.AccountNumber,
            Amount = request.Amount,
            MovimentDate = DateTime.UtcNow,
            MovementType = request.MovementType
        });

        return new CreateMovementCommandResponse()
        {
            MovementId = movementId
        };
    }
}