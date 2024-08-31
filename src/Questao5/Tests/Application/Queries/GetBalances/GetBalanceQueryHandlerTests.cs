using FluentAssertions;
using NSubstitute;
using Questao5.Application.Queries.Movements;
using Questao5.Domain.Services;
using Questao5.Tests.Fixtures.Entities;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Questao5.Tests.Application.Queries.GetBalances;

[Trait("Query Tests", "GetBalanceQueryHandler")]
public class GetBalanceQueryHandlerTests : IClassFixture<AccountFixture>
{
    private readonly AccountFixture _accountFixture;
    private readonly IMovementService _movementService;

    private GetBalanceQueryHandler _getBalanceQueryHandler;

    public GetBalanceQueryHandlerTests(AccountFixture accountFixture)
    {
        _accountFixture = accountFixture;
        _movementService = Substitute.For<IMovementService>();
    }

    [Fact(DisplayName = "HandleShouldNotThrowException")]
    public async Task HandleShouldNotThrowException()
    {
        // Arrange

        var account = _accountFixture.Generate();
        var query = new GetBalanceQuery
        {
            AccountNumber = account.Number
        };

        _movementService.ValidateAccountAsync(account.Number).Returns(account);

        _getBalanceQueryHandler = new GetBalanceQueryHandler(_movementService);

        // Act

        var result = await _getBalanceQueryHandler.Handle(query, CancellationToken.None);

        // Assert

        result.Should().NotBeNull();
    }
}