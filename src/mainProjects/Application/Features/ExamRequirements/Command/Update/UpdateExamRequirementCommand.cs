using MediatR;

namespace Application.Features.ExamRequirements.Command.Update;
public class UpdateExamRequirementCommand : IRequest<UpdateExamRequirementCommand>
{
    public int Id { get; set; }
    public string Detail { get; set; } = default!;
}
