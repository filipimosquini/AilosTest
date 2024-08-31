using System;
using FluentAssertions;
using Questao5.Application.Commands.Movements;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Questao5.Tests.Application.Commands.CreateMovements;

[Trait("Command Tests", "CreateMovementCommandValidator")]
public class CreateMovementCommandValidatorTests
{
    private CreateMovementCommandValidator _validator;

    [Fact(DisplayName = "ShouldHaveNoErrors")]
    public async Task ShouldHaveNoErrors()
    {
        // Arrange

        var command = new CreateMovementCommand
        {
            AccountNumber = 123,
            MovementType = "C",
            Amount = 100,
            RequestId = Guid.NewGuid().ToString()
        };

        _validator = new CreateMovementCommandValidator();

        // Act

        var result = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert

        result.Errors.Should().BeEmpty();
    }

    [Fact(DisplayName = "ShouldHaveErrors")]
    public async Task ShouldHaveErrors()
    {
        // Arrange

        var command = new CreateMovementCommand
        {
            AccountNumber = -1,
            MovementType = "E",
            Amount = -1
        };

        _validator = new CreateMovementCommandValidator();

        // Act

        var result = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert

        result.Errors.Should().NotBeEmpty();
    }
}