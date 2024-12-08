using FluentValidation;

namespace Application.Features.Questions.Command.Update;
public class UpdateQuestionValidator : AbstractValidator<UpdateQuestionCommand>
{
    public UpdateQuestionValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id is required");

        RuleFor(x => x.QuestionDetail).NotEmpty().WithMessage("Question detail is required");
        RuleFor(x => x.QuestionDetail).MaximumLength(255).WithMessage("Question detail max length has to be less than 255");

        RuleFor(x => x.VacancyId).GreaterThan(0).WithMessage("Vacancy id is required");
        RuleFor(x => x.OptionCount).GreaterThan(0).WithMessage("Option count is required");
    }
}
