using Application.Features.ExamRequirements.Dto;
using Application.Features.ExamRequirements.Model;
using Application.Services.ExamRequirementServices;
using AutoMapper;
using MediatR;

namespace Application.Features.ExamRequirements.Query.GetList;
public class GetExamRequirementListQuery : IRequest<ExamRequirementListModel>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetExamRequirementListQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}

public class GetExamRequirementListQueryHandler(IExamRequirementServices examRequirementService, IMapper mapper) : IRequestHandler<GetExamRequirementListQuery, ExamRequirementListModel>
{
    public async Task<ExamRequirementListModel> Handle(GetExamRequirementListQuery request, CancellationToken cancellationToken)
    {
        var examRequirements = await examRequirementService.GetPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

        var examRequirementListModel = mapper.Map<ExamRequirementListModel>(examRequirements);

        return examRequirementListModel;
    }
}
