using Application.Features.ExamRequirements.Dto;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExamRequirements.Command.Create;
public class CreateExamRequirementCommand : IRequest<CreateExamRequirementDto>
{
    public string Detail { get; set; } = default!;
}

public class CreateExamRequirementHandler : IRequestHandler<CreateExamRequirementCommand, CreateExamRequirementDto>
{
    private readonly IExamRequirementRepository _examRequirementRepository;
    private readonly IMapper _mapper;
    public CreateExamRequirementHandler(IExamRequirementRepository examRequirementRepository, IMapper mapper)
    {
        _examRequirementRepository = examRequirementRepository;
        _mapper = mapper;
    }
    public async Task<CreateExamRequirementDto> Handle(CreateExamRequirementCommand request, CancellationToken cancellationToken)
    {
        var examRequirement = _mapper.Map<ExamRequirement>(request);
        examRequirement.CreatedDate = DateTime.Now;
        await _examRequirementRepository.AddAsync(examRequirement);
        return _mapper.Map<CreateExamRequirementDto>(examRequirement);
    }
}
