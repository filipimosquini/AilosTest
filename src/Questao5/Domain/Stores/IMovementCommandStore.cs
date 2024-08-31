using System.Threading.Tasks;
using System;
using Questao5.Infrastructure.Database.Movements.Models;

namespace Questao5.Domain.Stores;

public interface IMovementCommandStore
{
    Task<Guid> AddMovementAsync(CreateMovementRequest request);
}