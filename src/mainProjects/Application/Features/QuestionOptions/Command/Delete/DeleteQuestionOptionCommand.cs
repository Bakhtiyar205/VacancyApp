using Application.Services.QuestionOptionServices;
using MediatR;

namespace Application.Features.QuestionOptions.Command.Delete;
public class DeleteQuestionOptionCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}

public class DeleteQuestionOptionCommandHandler(IQuestionOptionService questionOptionService) : IRequestHandler<DeleteQuestionOptionCommand, Unit>
{
    public async Task<Unit> Handle(DeleteQuestionOptionCommand request, CancellationToken cancellationToken)
    {
        var questionOption = await questionOptionService.GetAsync(request.Id, cancellationToken);

        await questionOptionService.DeleteAsync(questionOption, cancellationToken);

        return Unit.Value;
    }
}
