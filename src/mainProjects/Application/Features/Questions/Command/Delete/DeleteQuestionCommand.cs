using Application.Features.QuestionOptions.Constant;
using Application.Features.QuestionOptions.Rules;
using Application.Services.QuestionOptionServices;
using Application.Services.QuestionServices;
using Domain.Entities;
using MediatR;

namespace Application.Features.Questions.Command.Delete;
public class DeleteQuestionCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}
public class DeleteQuestionCommandHandler(IQuestionService questionService, IQuestionOptionService questionOptionService, QuestionOptionRules questionOptionRules) : IRequestHandler<DeleteQuestionCommand, Unit>
{
    public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await questionService.GetAsync(request.Id, cancellationToken);

        var questionOptionList = await questionOptionService.GetPaginateAsync(0, 1, request.Id, cancellationToken);

        questionOptionRules.CheckList(questionOptionList.Items, QuestionOptionMessages.QuestionQuestionOptionNotNull);

        await questionService.DeleteAsync(question, cancellationToken);

        return Unit.Value;
    }
}
