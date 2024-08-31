using System;
using System.Linq;
using System.Threading.Tasks;
using Questao5.Application.Commands.Movements;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Services;
using Questao5.Domain.Stores;
using Questao5.Infrastructure.Database.Movements.Models;
using Questao5.Infrastructure.Exceptions;

namespace Questao5.Infrastructure.Services.Movements;

public class MovementService : IMovementService
{
    private readonly IMovementQueryStore _movementQueryStore;
    private readonly IMovementCommandStore _movementCommandStore;

    public MovementService(IMovementQueryStore movementQueryStore, IMovementCommandStore movementCommandStore)
    {
        _movementQueryStore = movementQueryStore;
        _movementCommandStore = movementCommandStore;
    }

    public async Task<Guid> CreateMovementAsync(CreateMovementCommand command)
    {
        var movementId = await _movementCommandStore.AddMovementAsync(new CreateMovementRequest()
        {
            AccountNumber = command.AccountNumber,
            Amount = command.Amount,
            MovimentDate = DateTime.UtcNow,
            MovementType = command.MovementType
        });

        return movementId;
    }

    public async Task<double> GetBalanceAsync(int accountNumber)
    {
        var movements = await _movementQueryStore.GetMovementsByAccountNumberAsync(accountNumber);

        if (movements is null || (movements is not null && !movements.Any()))
        {
            return 0.0D;
        }

        var credits = movements
            .Where(x => x.MovementType == MovementTypeEnum.C)
            .Sum(x => x.Amount);

        var debits = movements
            .Where(x => x.MovementType == MovementTypeEnum.D)
            .Sum(x => x.Amount);

        return Math.Round((credits - debits), 2);
    }

    public async Task<Account> ValidateAccountAsync(int accountNumber)
    {
        var account = await _movementQueryStore.GetAccountAsync(accountNumber);

        if (account is null)
        {
            throw new AccountNotFoundException();
        }

        if (!account.Active)
        {
            throw new AccountInactiveException();
        }

        return account;
    }
}