using Application.Features.ExamRequirements.Dto;
using Application.Services.ExamRequirementServices;
using AutoMapper;
using MediatR;

namespace Application.Features.ExamRequirements.Query.GetById;
public class GetExamRequirementByIdQuery : IRequest<GetExamRequirementDto>
{
    public int Id { get; set; }

    public GetExamRequirementByIdQuery(int id)
    {
        Id = id;
    }
}

public class GetExamRequirementByIdQueryHandler(IExamRequirementServices examRequirementService, IMapper mapper) : IRequestHandler<GetExamRequirementByIdQuery, GetExamRequirementDto>
{
    private readonly IExamRequirementServices _examRequirementService = examRequirementService;
    private readonly IMapper _mapper = mapper;

    public async Task<GetExamRequirementDto> Handle(GetExamRequirementByIdQuery request, CancellationToken cancellationToken)
    {
        var examRequirement = await _examRequirementService.GetAsync(request.Id, cancellationToken);

        var examRequirementDto = _mapper.Map<GetExamRequirementDto>(examRequirement);

        return examRequirementDto;
    }
}
