using Dapper;
using Questao5.Domain.Stores;
using System.Data;
using System.Threading.Tasks;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.Movements;

public class MovementQueryStore : IMovementQueryStore
{
    private readonly IDbConnection _dbConnection;

    public MovementQueryStore(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Account> GetAccountAsync(int accountNumber)
    {
        string sql = @"

SELECT
    C.idcontacorrente AS ""Id"",
    C.numero AS ""Number"",
    C.nome AS ""Holder"",
    C.ativo AS ""Active""
FROM contacorrente AS C
WHERE C.numero = @numero
";

        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("numero", accountNumber, DbType.Int32);

        return await _dbConnection.QueryFirstOrDefaultAsync<Account>(sql, parameters);
    }
}