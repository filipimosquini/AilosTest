using Questao5.Domain.Entities;
using System;
using Questao5.Domain.Enumerators;
using Xunit;

namespace Questao5.Tests.Fixtures.Entities;

public class MovementFixtureCollection : ICollectionFixture<MovementFixture> { }

public class MovementFixture : IDisposable
{
    public MovementFixture() { }

    public Movement Generate(MovementTypeEnum movementType = MovementTypeEnum.C, 
                             int accountNumber = 123, 
                             double amount = 0.0D,
                             bool generateRandomId = false)
    {
        string _id = "da895097-8ff3-4743-bff6-2e772994bc09";

        if (generateRandomId)
        {
            _id = Guid.NewGuid().ToString();
        }

        return new Movement
        {
            MovementType = movementType,
            AccountNumber = accountNumber,
            Amount = amount,
            MovimentDate = DateTime.UtcNow,
            MovementId = Guid.Parse(_id),
        };
    }

    public Movement MovementNull
        => null;

    public void Dispose() { }
}