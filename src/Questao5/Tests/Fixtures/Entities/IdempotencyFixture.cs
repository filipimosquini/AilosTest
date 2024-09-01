using Questao5.Domain.Entities;
using System;

namespace Questao5.Tests.Fixtures.Entities;

public class IdempotencyFixture : IDisposable
{
    public IdempotencyFixture() { }

    public Idempotency Generate(bool generateRandomId = false)
    {
        string _id = "25561A63-FE01-41FB-BB97-87E4A9B64AC1";

        if (generateRandomId)
        {
            _id = Guid.NewGuid().ToString();
        }

        return new Idempotency
        {
            Id = _id,
            Request = "\"{\\r\\n  'requestId': '25561a63-fe01-41fb-bb97-87e4a9b64ac1',\\r\\n  'accountNumber': 123,\\r\\n  'amount': 300,\\r\\n  'movementType': 'C'\\r\\n}\"",
            Response = "\"{'data':{'movementId':'5665e52e-89b1-40fc-8984-3320b0803a8a'}}\""
        };
    }

    public Idempotency IdempotencyNull
        => null;

    public void Dispose() { }
}