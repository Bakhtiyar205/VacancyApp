using Application.Services.ExamRequirementServices;
using MediatR;

namespace Application.Features.ExamRequirements.Command.Delete;
public class DeleteExamRequirementCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public DeleteExamRequirementCommand(int id)
    {
        Id = id;
    }
}

public class DeleteExamRequirementCommandHandler(IExamRequirementServices examRequirementService) : IRequestHandler<DeleteExamRequirementCommand, Unit>
{
    public async Task<Unit> Handle(DeleteExamRequirementCommand request, CancellationToken cancellationToken)
    {
        var examRequirement = await examRequirementService.GetAsync(request.Id, cancellationToken);

        await examRequirementService.DeleteAsync(examRequirement);

        return Unit.Value;
    }
}
