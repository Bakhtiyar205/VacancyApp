using FluentValidation;

namespace Application.Features.Vacancies.Command.Create;
public class CreateVacancyValidator : AbstractValidator<CreateVacancyCommand>
{
    public CreateVacancyValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Title).MaximumLength(50).WithMessage("Title max length has to be less than 50");

        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.Description).MaximumLength(255).WithMessage("Description max length has to be less than 255");
    }
}
