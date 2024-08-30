using Dapper;
using Questao5.Domain.Stores;
using System.Data;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Database.QueryStore.Movements;

public class MovementQueryStore : IMovementQueryStore
{
    private readonly IDbConnection _dbConnection;

    public MovementQueryStore(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task Get()
    {
        var teste = await _dbConnection.QueryAsync<dynamic>("SELECT * FROM contacorrente");
    }
}