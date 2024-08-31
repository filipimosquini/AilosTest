using FluentAssertions;
using NSubstitute;
using Questao5.Application.Commands.Movements;
using Questao5.Domain.Services;
using Questao5.Tests.Fixtures.Entities;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Questao5.Tests.Application.Commands.CreateMovements;

[Trait("Command Tests", "CreateMovementCommandHandler")]
public class CreateMovementCommandHandlerTests : IClassFixture<AccountFixture>, IClassFixture<MovementFixture>
{
    private readonly AccountFixture _accountFixture;
    private readonly MovementFixture _movementFixture;
    private readonly IMovementService _movementService;

    private CreateMovementCommandHandler _createMovementCommandHandler;

    public CreateMovementCommandHandlerTests(AccountFixture accountFixture, MovementFixture movementFixture)
    {
        _accountFixture = accountFixture;
        _movementFixture = movementFixture;
        _movementService = Substitute.For<IMovementService>();
    }

    [Fact(DisplayName = "HandleShouldNotThrowException")]
    public async Task HandleShouldNotThrowException()
    {
        // Arrange

        var account = _accountFixture.Generate();
        var movement = _movementFixture.Generate();
        var command = new CreateMovementCommand
        {
            AccountNumber = account.Number,
            MovementType = movement.MovementType.ToString(),
            Amount = movement.Amount
        };

        _movementService.ValidateAccountAsync(account.Number).Returns(account);

        _movementService.CreateMovementAsync(command).ReturnsForAnyArgs(movement.MovementId);

        _createMovementCommandHandler = new CreateMovementCommandHandler(_movementService);

        // Act

        var result = await _createMovementCommandHandler.Handle(command, CancellationToken.None);

        // Assert

        result.Should().NotBeNull();
    }
}