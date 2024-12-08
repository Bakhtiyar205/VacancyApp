using Application.Features.QuestionOptions.Dto;
using Application.Services.QuestionOptionServices;
using AutoMapper;
using MediatR;

namespace Application.Features.QuestionOptions.Query.GetById;
public class GetQuestionOptionByIdQuery(int id) : IRequest<GetQuestionOptionDto>
{
    public int Id { get; set; } = id;
}

public class GetQuestionOptionByIdQueryHandler(IQuestionOptionService questionOptionService, IMapper mapper) : IRequestHandler<GetQuestionOptionByIdQuery, GetQuestionOptionDto>
{
    public async Task<GetQuestionOptionDto> Handle(GetQuestionOptionByIdQuery request, CancellationToken cancellationToken)
    {
        var questionOption = await questionOptionService.GetAsync(request.Id, cancellationToken);

        return mapper.Map<GetQuestionOptionDto>(questionOption);
    }
}
