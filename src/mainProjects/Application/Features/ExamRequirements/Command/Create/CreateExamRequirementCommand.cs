using Application.Features.ExamRequirements.Dto;
using Application.Services.ExamRequirementServices;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExamRequirements.Command.Create;
public class CreateExamRequirementCommand : IRequest<CreateExamRequirementDto>
{
    public string Detail { get; set; } = default!;
}

public class CreateExamRequirementHandler(IExamRequirementServices examRequirementService, IMapper mapper) : IRequestHandler<CreateExamRequirementCommand, CreateExamRequirementDto>
{
    public async Task<CreateExamRequirementDto> Handle(CreateExamRequirementCommand request, CancellationToken cancellationToken)
    {
        var examRequirement = mapper.Map<ExamRequirement>(request);

        await examRequirementService.CreateAsync(examRequirement);

        return mapper.Map<CreateExamRequirementDto>(examRequirement);
    }
}
