using FluentValidation;

namespace Application.Features.QuestionOptions.Command.Delete;
public class DeleteQuestionOptionValidator : AbstractValidator<DeleteQuestionOptionCommand>
{
    public DeleteQuestionOptionValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id is required");
    }
}
