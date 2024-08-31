using FluentValidation;

namespace Questao5.Application.Queries.Movements;

public class GetBalanceQueryValidator : AbstractValidator<GetBalanceQuery>
{
    public GetBalanceQueryValidator()
    {
        RuleFor(x => x.AccountNumber)
            .GreaterThan(0)
            .WithErrorCode("INVALID_ACCOUNT_NUMBER");
    }
}