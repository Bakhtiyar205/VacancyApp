using Application.Services.QuestionServices;
using MediatR;

namespace Application.Features.Questions.Command.Delete;
public class DeleteQuestionCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}
public class DeleteQuestionCommandHandler(IQuestionService questionService) : IRequestHandler<DeleteQuestionCommand, Unit>
{
    public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await questionService.GetAsync(request.Id, cancellationToken);

        await questionService.DeleteAsync(question, cancellationToken);

        return Unit.Value;
    }
}
