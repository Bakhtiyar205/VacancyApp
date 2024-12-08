using FluentValidation;

namespace Application.Features.QuestionOptions.Command.Update;
public class UpdateQuestionOptionValidator : AbstractValidator<UpdateQuestionOptionCommand>
{
    public UpdateQuestionOptionValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id is required");

        RuleFor(x => x.Option).NotEmpty().WithMessage("Option is required");
        RuleFor(x => x.Option).MaximumLength(255).WithMessage("Option must not exceed 255 characters");

        RuleFor(x => x.QuestionId).GreaterThan(0).WithMessage("Question is required");
    }
}
