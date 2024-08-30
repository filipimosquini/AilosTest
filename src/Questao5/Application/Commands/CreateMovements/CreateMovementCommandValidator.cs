using System;
using FluentValidation;

namespace Questao5.Application.Commands.Movements;

public class CreateMovementCommandValidator : AbstractValidator<CreateMovementCommand>
{
    public CreateMovementCommandValidator()
    {
        RuleFor(x => x.RequestId)
            .Must(BeValidId)
            .WithErrorCode("INVALID_REQUEST_ID");

        RuleFor(x => x.AccountId)
            .Must(BeValidId)
            .WithErrorCode("INVALID_ACCOUNT_ID");

        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithErrorCode("INVALID_VALUE");

        RuleFor(x => x.MovementType)
            .IsInEnum()
            .WithErrorCode("INVALID_TYPE");
    }

    private bool BeValidId(string id)
        => Guid.TryParse(id, out _);
}