using Questao5.Infrastructure.Database.Idempotencies.Models;
using System.Threading.Tasks;

namespace Questao5.Domain.Stores;

public interface IIdempotencyCommandStore
{
    Task AddIdepotencyAsync(CreateIdepotencyRequest request);
    Task UpdateIdepotencyResponse(UpdateIdepotencyRequest request);
}