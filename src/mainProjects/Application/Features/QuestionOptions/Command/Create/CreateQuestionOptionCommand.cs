﻿using Application.Features.QuestionOptions.Dto;
using Application.Features.QuestionOptions.Rules;
using Application.Services.QuestionOptionServices;
using Application.Services.QuestionServices;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.QuestionOptions.Command.Create;
public class CreateQuestionOptionCommand : IRequest<CreateQuestionOptionDto>
{
    public string Option { get; set; } = default!;
    public bool IsAnswer { get; set; }
    public int QuestionId { get; set; }
}

public class CreateQuestionOptionCommandHandler(IQuestionOptionService questionOptionService, IQuestionService questionService, IMapper mapper, QuestionOptionRules questionOptionRules)
                                               : IRequestHandler<CreateQuestionOptionCommand, CreateQuestionOptionDto>
{
    public async Task<CreateQuestionOptionDto> Handle(CreateQuestionOptionCommand request, CancellationToken cancellationToken)
    {
        var questionOption = mapper.Map<QuestionOption>(request);

        var question = await questionService.GetAsync(request.QuestionId);

        var answeredQuestionOption = await questionOptionService.GetPaginateAsync(0, 1, request.QuestionId, cancellationToken);

        questionOptionRules.EnsureCorrectAnswerFirst(answeredQuestionOption.Items, request.IsAnswer);

        questionOptionRules.CheckSecondaryAnswer(answeredQuestionOption.Items, request.IsAnswer);

        await questionOptionService.CheckQuestionLimit(question.Id, question.OptionCount, cancellationToken: cancellationToken);

        questionOption = await questionOptionService.CreateAsync(questionOption);

        return mapper.Map<CreateQuestionOptionDto>(questionOption);
    }
}
