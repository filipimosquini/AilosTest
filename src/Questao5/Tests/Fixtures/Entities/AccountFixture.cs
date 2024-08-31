using System;
using Questao5.Domain.Entities;
using Xunit;

namespace Questao5.Tests.Fixtures.Entities;

public class AccountFixtureCollection : ICollectionFixture<AccountFixture> { }

public class AccountFixture : IDisposable
{
    public AccountFixture() { }

    public Account Generate(int number = 123, string holder = "holder", bool active = true, bool generateRandomId = false)
    {
        string _id = "da895097-8ff3-4743-bff6-2e772994bc09";

        if (generateRandomId)
        {
            _id = Guid.NewGuid().ToString();
        }

        return new Account
        {
            Id = _id,
            Active = active,
            Holder = holder,
            Number = number
        };
    }

    public Account AccountNull
        => null;

    public void Dispose() { }
}