using System;
using Dapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Stores;
using System.Data;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Database.Idepotencies;

public class IdepotencyQueryStore : IIdepotencyQueryStore
{
    private readonly IDbConnection _dbConnection;

    public IdepotencyQueryStore(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Idepotency> GetIdepotencyAsync(Guid idepotencyToken)
    {
        string sql = @"
                        SELECT
                            I.chave_idempotencia       AS ""Id"",
                            I.requisicao               AS ""Request"",
                            I.resultado                AS ""Response""
                        FROM idempotencia I
                        WHERE I.chave_idempotencia = @chave_idempotencia
                     ";

        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("chave_idempotencia", idepotencyToken, DbType.Guid);

        return await _dbConnection.QueryFirstOrDefaultAsync<Idepotency>(sql, parameters);
    }
}