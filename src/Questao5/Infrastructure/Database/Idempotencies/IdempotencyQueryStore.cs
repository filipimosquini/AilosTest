using System;
using Dapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Stores;
using System.Data;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Database.Idempotencies;

public class IdempotencyQueryStore : IIdempotencyQueryStore
{
    private readonly IDbConnection _dbConnection;

    public IdempotencyQueryStore(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Idempotency> GetIdepotencyAsync(Guid idepotencyToken)
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

        return await _dbConnection.QueryFirstOrDefaultAsync<Idempotency>(sql, parameters);
    }
}