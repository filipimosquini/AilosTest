using Questao5.Domain.Entities;
using System.Threading.Tasks;

namespace Questao5.Domain.Stores;

public interface IMovementQueryStore
{
    Task<Account> GetAccountAsync(int accountNumber);
}