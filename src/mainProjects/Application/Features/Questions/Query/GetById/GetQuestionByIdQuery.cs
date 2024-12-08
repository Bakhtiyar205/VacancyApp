using Application.Features.Questions.Dto;
using Application.Services.QuestionServices;
using AutoMapper;
using MediatR;

namespace Application.Features.Questions.Query.GetById;
public class GetQuestionByIdQuery(int id) : IRequest<GetQuestionDto>
{
    public int Id { get; set; } = id;
}

public class GetQuestionByIdQueryHandler(IQuestionService questionService, IMapper mapper) : IRequestHandler<GetQuestionByIdQuery, GetQuestionDto>
{
    public async Task<GetQuestionDto> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var question = await questionService.GetAsync(request.Id, cancellationToken);

        return mapper.Map<GetQuestionDto>(question);
    }
}
