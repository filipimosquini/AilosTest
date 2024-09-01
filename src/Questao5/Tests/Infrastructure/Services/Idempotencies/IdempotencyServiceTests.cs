using FluentAssertions;
using NSubstitute;
using Questao5.Domain.Stores;
using Questao5.Infrastructure.Database.Idempotencies.Models;
using Questao5.Infrastructure.Services.Idempotencies;
using Questao5.Tests.Fixtures.Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Questao5.Tests.Infrastructure.Services.Idempotencies;

[Trait("Service Tests", "IdempotencyService")]
public class IdempotencyServiceTests : IClassFixture<IdempotencyFixture>
{
    private readonly IdempotencyFixture _idempotencyFixture;

    private readonly IIdempotencyQueryStore _idempotencyQueryStore;
    private readonly IIdempotencyCommandStore _idempotencyCommandStore;

    private IdempotencyService _idempotencyService;

    public IdempotencyServiceTests(IdempotencyFixture idempotencyFixture)
    {
        _idempotencyFixture = idempotencyFixture;
        _idempotencyQueryStore = Substitute.For<IIdempotencyQueryStore>();
        _idempotencyCommandStore = Substitute.For<IIdempotencyCommandStore>();
    }

    [Fact(DisplayName = "CreateIdempotencyAsyncShouldNotThrowException")]
    public async Task CreateIdempotencyAsyncShouldNotThrowException()
    {
        // Arrange 

        var idempotency = _idempotencyFixture.Generate();

        _idempotencyCommandStore.AddIdepotencyAsync(new CreateIdepotencyRequest
        {
            Request = idempotency.Request,
            Id = Guid.Parse(idempotency.Id)
        });

        _idempotencyService = new IdempotencyService(_idempotencyQueryStore, _idempotencyCommandStore);

        // Act

        var result = await _idempotencyService.CreateIdepotencyAsync(Guid.Parse(idempotency.Id), idempotency.Request);

        // Assert

        result.Should().NotBeNull();
    }

    [Fact(DisplayName = "UpdateIdepotencyAsyncShouldNotThrowException")]
    public async Task UpdateIdepotencyAsyncShouldNotThrowException()
    {
        // Arrange 

        var idempotency = _idempotencyFixture.Generate();

        _idempotencyCommandStore.UpdateIdepotencyResponse(new UpdateIdepotencyRequest
        {
            Response = idempotency.Response,
            Id = Guid.Parse(idempotency.Id)
        });

        _idempotencyService = new IdempotencyService(_idempotencyQueryStore, _idempotencyCommandStore);

        // Act

        var act = async ()  => await _idempotencyService.UpdateIdepotencyAsync(Guid.Parse(idempotency.Id), idempotency.Response);

        // Assert

        await act.Should().NotThrowAsync();
    }
}