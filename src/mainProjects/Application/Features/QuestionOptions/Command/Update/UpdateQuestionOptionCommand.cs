using Application.Features.QuestionOptions.Dto;
using Application.Services.QuestionOptionServices;
using Application.Services.QuestionServices;
using AutoMapper;
using MediatR;

namespace Application.Features.QuestionOptions.Command.Update;
public class UpdateQuestionOptionCommand : IRequest<UpdateQuestionOptionDto>
{
    public int Id { get; set; }
    public string Option { get; set; } = default!;
    public bool IsAnswer { get; set; }
    public int QuestionId { get; set; }
}

public class UpdateQuestionOptionCommandHandler(IQuestionOptionService questionOptionService, IQuestionService questionService, IMapper mapper)
                                               : IRequestHandler<UpdateQuestionOptionCommand, UpdateQuestionOptionDto>
{
    public async Task<UpdateQuestionOptionDto> Handle(UpdateQuestionOptionCommand request, CancellationToken cancellationToken)
    {
        var questionOption = await questionOptionService.GetAsync(request.Id, cancellationToken);

        await questionService.GetAsync(request.QuestionId);

        questionOption = mapper.Map(request, questionOption);

        questionOption = await questionOptionService.UpdateAsync(questionOption, cancellationToken);

        return mapper.Map<UpdateQuestionOptionDto>(questionOption);
    }
}
