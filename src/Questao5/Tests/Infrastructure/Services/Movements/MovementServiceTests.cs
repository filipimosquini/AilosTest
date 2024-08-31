using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using Questao5.Application.Commands.Movements;
using Questao5.Domain.Stores;
using Questao5.Infrastructure.Database.Movements.Models;
using Questao5.Infrastructure.Exceptions;
using Questao5.Infrastructure.Services.Movements;
using Questao5.Tests.Fixtures.Entities;
using System.Net;
using System.Threading.Tasks;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Xunit;

namespace Questao5.Tests.Infrastructure.Services.Movements;

[Trait("Service Tests", "MovementService")]
public class MovementServiceTests : IClassFixture<AccountFixture>, IClassFixture<MovementFixture>
{
    private readonly AccountFixture _accountFixture;
    private readonly MovementFixture _movementFixture;

    private readonly IMovementQueryStore _movementQueryStore;
    private readonly IMovementCommandStore _movementCommandStore;

    private MovementService _movementService;

    public MovementServiceTests(AccountFixture accountFixture, MovementFixture movementFixture)
    {
        _accountFixture = accountFixture;
        _movementFixture = movementFixture;
        _movementQueryStore = Substitute.For<IMovementQueryStore>();
        _movementCommandStore = Substitute.For<IMovementCommandStore>();
    }

    [Fact(DisplayName = "ValidateAccountAsyncShouldNotThrowException")]
    public async Task ValidateAccountAsyncShouldNotThrowException()
    {
        // Arrange

        var account = _accountFixture.Generate();

        _movementQueryStore.GetAccountAsync(account.Number).Returns(account);

        _movementService = new MovementService(_movementQueryStore, _movementCommandStore);

        // Act

        var result = await _movementService.ValidateAccountAsync(account.Number);

        // Assert

        result.Should().NotBeNull();
    }

    [Fact(DisplayName = "ValidateAccountAsyncShouldThrowAccountNotFoundException")]
    public async Task ValidateAccountAsyncShouldThrowAccountNotFoundException()
    {
        // Arrange

        var account = _accountFixture.AccountNull;

        _movementQueryStore.GetAccountAsync(Arg.Any<int>()).Returns(account);

        _movementService = new MovementService(_movementQueryStore, _movementCommandStore);

        // Act

        var exception = await Assert
            .ThrowsAsync<AccountNotFoundException>(async () =>
            {
                await _movementService.ValidateAccountAsync(Arg.Any<int>());
            });

        // Assert

        exception.Message.Should().BeSameAs("INVALID_ACCOUNT");
        exception.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact(DisplayName = "ValidateAccountAsyncShouldThrowAccountInactiveException")]
    public async Task ValidateAccountAsyncShouldThrowAccountInactiveException()
    {
        // Arrange

        var account = _accountFixture.Generate(active:false);

        _movementQueryStore.GetAccountAsync(account.Number).Returns(account);

        _movementService = new MovementService(_movementQueryStore, _movementCommandStore);

        // Act

        var exception = await Assert
            .ThrowsAsync<AccountInactiveException>(async () =>
            {
                await _movementService.ValidateAccountAsync(account.Number);
            });

        // Assert

        exception.Message.Should().BeSameAs("INACTIVE_ACCOUNT");
        exception.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact(DisplayName = "CreateMovementAsyncShouldNotThrowException")]
    public async Task CreateMovementAsyncShouldNotThrowException()
    {
        // Arrange 

        var movement = _movementFixture.Generate();

        _movementCommandStore.AddMovementAsync(new CreateMovementRequest
        {
            Amount = movement.Amount,
            AccountNumber = movement.AccountNumber,
            MovementType = movement.MovementType.ToString()
        }).ReturnsForAnyArgs(movement.MovementId);

        _movementService = new MovementService(_movementQueryStore, _movementCommandStore);

        // Act

        var result = await _movementService.CreateMovementAsync(new CreateMovementCommand
        {
            Amount = movement.Amount,
            AccountNumber = movement.AccountNumber,
            MovementType = movement.MovementType.ToString()
        });

        // Assert

        result.Should().Be(movement.MovementId);
    }

    [Fact(DisplayName = "GetBalanceAsyncShouldReturnsPositiveBalance")]
    public async Task GetBalanceAsyncShouldReturnsPositiveBalance()
    {
        // Arrange 

        var movements = new List<Movement>()
        {
            _movementFixture.Generate(amount: 100),
            _movementFixture.Generate(amount: 200),
            _movementFixture.Generate(amount: 300),
        };

        var movement = _movementFixture.Generate();

        _movementQueryStore.GetMovementsByAccountNumberAsync(movement.AccountNumber).Returns(movements);

        _movementService = new MovementService(_movementQueryStore, _movementCommandStore);

        // Act

        var result = await _movementService.GetBalanceAsync(movement.AccountNumber);

        // Assert

        result.Should().BeGreaterThan(0);
    }

    [Fact(DisplayName = "GetBalanceAsyncShouldReturnsNegativeBalance")]
    public async Task GetBalanceAsyncShouldReturnsNegativeBalance()
    {
        // Arrange 

        var movements = new List<Movement>()
        {
            _movementFixture.Generate(MovementTypeEnum.D, amount: 100),
            _movementFixture.Generate(MovementTypeEnum.D, amount: 200),
            _movementFixture.Generate(MovementTypeEnum.D, amount: 300),
        };

        var movement = _movementFixture.Generate();

        _movementQueryStore.GetMovementsByAccountNumberAsync(movement.AccountNumber).Returns(movements);

        _movementService = new MovementService(_movementQueryStore, _movementCommandStore);

        // Act

        var result = await _movementService.GetBalanceAsync(movement.AccountNumber);

        // Assert

        result.Should().BeLessThan(0);
    }

    [Fact(DisplayName = "GetBalanceAsyncShouldReturnsZero")]
    public async Task GetBalanceAsyncShouldReturnsZero()
    {
        // Arrange 

        var movement = _movementFixture.Generate();

        _movementQueryStore.GetMovementsByAccountNumberAsync(movement.AccountNumber);

        _movementService = new MovementService(_movementQueryStore, _movementCommandStore);

        // Act

        var result = await _movementService.GetBalanceAsync(movement.AccountNumber);

        // Assert

        result.Should().Be(0);
    }
}