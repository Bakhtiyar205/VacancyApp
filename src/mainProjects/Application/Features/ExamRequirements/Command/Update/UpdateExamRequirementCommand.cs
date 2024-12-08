using Application.Features.ExamRequirements.Dto;
using Application.Services.ExamRequirementServices;
using AutoMapper;
using MediatR;

namespace Application.Features.ExamRequirements.Command.Update;
public class UpdateExamRequirementCommand : IRequest<UpdateExamRequirementDto>
{
    public int Id { get; set; }
    public string Detail { get; set; } = default!;
}

public class UpdateExamRequirementCommandHandler(IExamRequirementServices examRequirementService, IMapper mapper) : IRequestHandler<UpdateExamRequirementCommand, UpdateExamRequirementDto>
{
    public async Task<UpdateExamRequirementDto> Handle(UpdateExamRequirementCommand request, CancellationToken cancellationToken)
    {
        var examRequirement = await examRequirementService.GetAsync(request.Id, cancellationToken);

        examRequirement = mapper.Map(request, examRequirement);

        examRequirement = await examRequirementService.UpdateAsync(examRequirement, cancellationToken);

        var examRequirementDto = mapper.Map<UpdateExamRequirementDto>(examRequirement);

        return examRequirementDto;
    }
}
