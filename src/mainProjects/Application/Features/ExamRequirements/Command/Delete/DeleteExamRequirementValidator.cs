using FluentValidation;

namespace Application.Features.ExamRequirements.Command.Delete;
public class DeleteExamRequirementValidator : AbstractValidator<DeleteExamRequirementCommand>
{
    public DeleteExamRequirementValidator()
    {
        RuleFor(x => x.Id).LessThanOrEqualTo(0).WithMessage("Id has to be greater than 0");
    }
}
