using Application.Features.Questions.Model;
using Application.Services.QuestionServices;
using AutoMapper;
using MediatR;

namespace Application.Features.Questions.Query.GetList;
public class GetQuestionListQuery(int pageNumber, int pageSize, int vacancyId) : IRequest<QuestionListModel>
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int VacancyId { get; set; } = vacancyId;
}

public class GetQuestionListQueryHandler(IQuestionService questionService, IMapper mapper) : IRequestHandler<GetQuestionListQuery, QuestionListModel>
{
    public async Task<QuestionListModel> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
    {
        var paginated = await questionService.GetPaginatedAsync(request.PageNumber, request.PageSize, request.VacancyId, cancellationToken);

        return mapper.Map<QuestionListModel>(paginated);
    }
}
