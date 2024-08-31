using Dapper;
using Questao5.Domain.Stores;
using Questao5.Infrastructure.Database.Movements.Models;
using Questao5.Infrastructure.Exceptions;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Database.Movements;

public class MovementCommandStore : IMovementCommandStore
{
    private readonly IDbConnection _dbConnection;

    public MovementCommandStore(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Guid> AddMovementAsync(CreateMovementRequest request)
    {
        Guid movementId = Guid.NewGuid();
        string sql = @"
INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor)
VALUES (@id, @idcontacorrente, @datamovimento, @tipomovimento, @valor)
";

        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("id", movementId, DbType.Guid);
        parameters.Add("idcontacorrente", request.AccountNumber, DbType.Int32);
        parameters.Add("datamovimento", DateTime.UtcNow, DbType.Date);
        parameters.Add("valor", request.Amount, DbType.Double);
        parameters.Add("tipomovimento", request.MovementType, DbType.String);

        var rowsAffected = await _dbConnection.ExecuteAsync(sql, parameters);

        if (rowsAffected == 0)
        {
            throw new MovementNotRegisteredException();
        }

        return movementId;
    }
}