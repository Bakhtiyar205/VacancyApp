using FluentValidation;

namespace Application.Features.ExamRequirements.Command.Create;
public class CreateExamRequirementValidator : AbstractValidator<CreateExamRequirementCommand>
{
    public CreateExamRequirementValidator()
    {
        RuleFor(x => x.Detail).NotEmpty().WithMessage("Detail is required");
        RuleFor(x => x.Detail).MaximumLength(255).WithMessage("Detail max length have to be less than 255");
    }
}
