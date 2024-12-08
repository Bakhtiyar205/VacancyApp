using FluentValidation;

namespace Application.Features.ExamRequirements.Command.Delete;
public class DeleteExamRequirementValidator : AbstractValidator<DeleteExamRequirementCommand>
{
    public DeleteExamRequirementValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id is required");
    }
}
