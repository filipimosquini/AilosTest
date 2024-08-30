using System.Threading.Tasks;

namespace Questao5.Domain.Stores;

public interface IMovementQueryStore
{
    Task Get();
}