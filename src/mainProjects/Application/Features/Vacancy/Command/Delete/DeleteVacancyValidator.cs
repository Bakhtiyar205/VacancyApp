using FluentValidation;

namespace Application.Features.Vacancies.Command.Delete;
public class DeleteVacancyValidator : AbstractValidator<DeleteVacancyCommand>
{
    public DeleteVacancyValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id is required");
    }
}
