using Questao5.Infrastructure.Database.Idepotencies.Models;
using System.Threading.Tasks;

namespace Questao5.Domain.Stores;

public interface IIdepotencyCommandStore
{
    Task AddIdepotencyAsync(CreateIdepotencyRequest request);
    Task UpdateIdepotencyResponse(UpdateIdepotencyRequest request);
}