using Questao5.Application.Commands.Movements;
using Questao5.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Questao5.Domain.Services;

public interface IMovementService
{
    Task<Guid> CreateMovementAsync(CreateMovementCommand command);
    Task<double> GetBalanceAsync(int accountNumber);
    Task<Account> ValidateAccountAsync(int accountNumber);
}