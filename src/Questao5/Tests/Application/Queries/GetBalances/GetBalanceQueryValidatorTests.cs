using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Questao5.Application.Queries.Movements;
using Xunit;

namespace Questao5.Tests.Application.Queries.GetBalances;

[Trait("Query Tests", "GetBalanceQueryValidator")]
public class GetBalanceQueryValidatorTests
{

    private GetBalanceQueryValidator _validator;

    [Fact(DisplayName = "ShouldHaveNoErrors")]
    public async Task ShouldHaveNoErrors()
    {
        // Arrange

        var command = new GetBalanceQuery
        {
            AccountNumber = 123
        };

        _validator = new GetBalanceQueryValidator();

        // Act

        var result = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert

        result.Errors.Should().BeEmpty();
    }

    [Fact(DisplayName = "ShouldHaveErrors")]
    public async Task ShouldHaveErrors()
    {
        // Arrange

        var command = new GetBalanceQuery
        {
            AccountNumber = -1,
        };

        _validator = new GetBalanceQueryValidator();

        // Act

        var result = await _validator.ValidateAsync(command, CancellationToken.None);

        // Assert

        result.Errors.Should().NotBeEmpty();
    }
}