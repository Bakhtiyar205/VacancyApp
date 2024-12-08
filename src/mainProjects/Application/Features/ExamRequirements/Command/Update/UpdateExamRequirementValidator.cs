using FluentValidation;

namespace Application.Features.ExamRequirements.Command.Update;
public class UpdateExamRequirementValidator : AbstractValidator<UpdateExamRequirementCommand>
{
    public UpdateExamRequirementValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id is required");

        RuleFor(x => x.Detail).NotEmpty().WithMessage("Detail is required");
        RuleFor(x => x.Detail).MaximumLength(255).WithMessage("Detail max length have to be less than 255");
    }
}
