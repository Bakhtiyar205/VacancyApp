using Application.Features.QuestionOptions.Model;
using Application.Services.QuestionOptionServices;
using AutoMapper;
using MediatR;

namespace Application.Features.QuestionOptions.Query.GetList;
public class GetQuestionOptionListQuery(int pageNumber, int pageSize, int questionId) : IRequest<QuestionOptionListModel>
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int QuestionId { get; set; } = questionId;
}

public class GetQuestionOptionListQueryHandler(IQuestionOptionService questionOptionService, IMapper mapper) 
                                              : IRequestHandler<GetQuestionOptionListQuery, QuestionOptionListModel>
{
    public async Task<QuestionOptionListModel> Handle(GetQuestionOptionListQuery request, CancellationToken cancellationToken)
    {
        var questionOptions = await questionOptionService.GetPaginateAsync(request.PageNumber, request.PageSize, request.QuestionId,cancellationToken);

        return mapper.Map<QuestionOptionListModel>(questionOptions);
    }
}
