using Application.Services.QuestionOptionServices;
using Application.Services.QuestionServices;
using MediatR;

namespace Application.Features.QuestionOptions.Command.DeleteByQuestion;
public class DeleteByQuestionCommand(int questionId, int size) : IRequest<Unit>
{
    public int QuestionId { get; set; } = questionId;
    public int Size { get; set; } = size;
}

public class DeleteByQuestionCommandHandler(IQuestionOptionService questionOptionService, IQuestionService questionService) : IRequestHandler<DeleteByQuestionCommand, Unit>
{
    public async Task<Unit> Handle(DeleteByQuestionCommand request, CancellationToken cancellationToken)
    {
        await questionService.GetAsync(request.QuestionId, cancellationToken);

        var questionOptionList = await questionOptionService.GetPaginateAsync(0, request.Size, request.QuestionId, cancellationToken);

        await questionOptionService.DeleteByQuestionAsync(questionOptionList.Items, cancellationToken);

        return Unit.Value;
    }
}
