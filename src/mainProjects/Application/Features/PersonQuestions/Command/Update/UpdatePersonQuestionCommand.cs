using Application.Services.PersonQuestionServices;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace Application.Features.PersonQuestions.Command.Update;
public class UpdatePersonQuestionCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int QuestionOptionId { get; set; }
}

public class UpdatePersonQuestionCommandHandler(IPersonQuestionService personQuestionService, IMapper mapper) : IRequestHandler<UpdatePersonQuestionCommand, Unit>
{
    public async Task<Unit> Handle(UpdatePersonQuestionCommand request, CancellationToken cancellationToken)
    {
        var personQuestion = await personQuestionService.GetByIdAsync(request.Id, cancellationToken);
        if(personQuestion.AnswerId != 0) throw new BusinessException("Question already answered");
        personQuestion.AnswerId = request.QuestionOptionId;
        await personQuestionService.UpdateAsync(personQuestion, cancellationToken);

        return Unit.Value;
    }
}
