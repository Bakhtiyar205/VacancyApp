using FluentValidation;

namespace Application.Features.Questions.Command.Create;
public class CreateQuestionValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.QuestionDetail).NotEmpty().WithMessage("Question detail is required");
        RuleFor(x => x.QuestionDetail).MaximumLength(255).WithMessage("Question detail max length has to be less than 255");

        RuleFor(x => x.VacancyId).GreaterThan(0).WithMessage("Vacancy id is required");

        RuleFor(x => x.OptionCount).GreaterThan(0).WithMessage("Option count is required");
    }
}
