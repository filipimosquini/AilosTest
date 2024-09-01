using Dapper;
using Questao5.Domain.Stores;
using Questao5.Infrastructure.Database.Idempotencies.Models;
using Questao5.Infrastructure.Exceptions;
using System.Data;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Database.Idempotencies;

public class IdempotencyCommandStore : IIdempotencyCommandStore
{
    private readonly IDbConnection _dbConnection;

    public IdempotencyCommandStore(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task AddIdepotencyAsync(CreateIdepotencyRequest request)
    {
        string sql = @"
                        insert into idempotencia (chave_idempotencia, requisicao)
                        values (@chave_idempotencia, @requisicao)
                      ";

        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("chave_idempotencia", request.Id, DbType.Guid);
        parameters.Add("requisicao", request.Request, DbType.String);

        var rowsAffected = await _dbConnection.ExecuteAsync(sql, parameters);

        if (rowsAffected == 0)
        {
            throw new MovementNotRegisteredException();
        }
    }

    public async Task UpdateIdepotencyResponse(UpdateIdepotencyRequest request)
    {
        string sql = @"
                        update idempotencia
                        set resultado = @resultado
                        where chave_idempotencia = @chave_idempotencia
                      ";

        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("chave_idempotencia", request.Id, DbType.Guid);
        parameters.Add("resultado", request.Response, DbType.String);

        var rowsAffected = await _dbConnection.ExecuteAsync(sql, parameters);

        if (rowsAffected == 0)
        {
            throw new MovementNotRegisteredException();
        }
    }
}