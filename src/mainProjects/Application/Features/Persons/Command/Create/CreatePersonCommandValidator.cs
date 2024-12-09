using FluentValidation;

namespace Application.Features.Persons.Command.Create;
public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

        RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.");
        RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Surname must not exceed 50 characters.");

        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
        RuleFor(x => x.Email).MaximumLength(50).WithMessage("Email must not exceed 50 characters.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid.");

        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required.");
        RuleFor(x => x.PhoneNumber).Matches(@"^\+?994(50|51|55|70|77)\d{7}$").WithMessage("PhoneNumber has to be registered in Azerbaijan");
        RuleFor(x => x.PhoneNumber).MaximumLength(30).WithMessage("PhoneNumber must not exceed 30 characters.");
    }
}
