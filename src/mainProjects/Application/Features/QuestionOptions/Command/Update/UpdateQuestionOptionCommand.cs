using Application.Features.QuestionOptions.Dto;
using Application.Features.QuestionOptions.Rules;
using Application.Services.QuestionOptionServices;
using Application.Services.QuestionServices;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.QuestionOptions.Command.Update;
public class UpdateQuestionOptionCommand : IRequest<UpdateQuestionOptionDto>
{
    public int Id { get; set; }
    public string Option { get; set; } = default!;
    public bool IsAnswer { get; set; }
    public int QuestionId { get; set; }
}

public class UpdateQuestionOptionCommandHandler(IQuestionOptionService questionOptionService, IQuestionService questionService, QuestionOptionRules questionOptionRules,IMapper mapper)
                                               : IRequestHandler<UpdateQuestionOptionCommand, UpdateQuestionOptionDto>
{
    public async Task<UpdateQuestionOptionDto> Handle(UpdateQuestionOptionCommand request, CancellationToken cancellationToken)
    {
        var questionOption = await questionOptionService.GetAsync(request.Id, cancellationToken);

        var question = await questionService.GetAsync(request.QuestionId);

        questionOption = mapper.Map(request, questionOption);

        var answeredQuestionOption = await questionOptionService.GetPaginateAsync(0, 1, request.QuestionId, cancellationToken);

        questionOptionRules.EnsureCorrectAnswerFirst(answeredQuestionOption.Items, request.IsAnswer);

        questionOptionRules.CheckSecondaryAnswer(answeredQuestionOption.Items, request.IsAnswer);

        await questionOptionService.CheckQuestionLimit(question.Id, question.OptionCount, cancellationToken: cancellationToken);

        questionOption = await questionOptionService.UpdateAsync(questionOption, cancellationToken);

        return mapper.Map<UpdateQuestionOptionDto>(questionOption);
    }
}
