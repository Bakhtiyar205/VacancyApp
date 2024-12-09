using Application.Services.PersonQuestionServices;
using Application.Services.PersonServices;
using Application.Services.PersonVacancyServices;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Persons.Command.Delete;
public class DeletePersonCommand : IRequest<Unit>, ITransactionalRequest
{
    public int Id { get; set; }
}

public class DeletePersonCommandHandler(IPersonService personService, IPersonVacancyService personVacancyService, IPersonQuestionService personQuestionService) : IRequestHandler<DeletePersonCommand, Unit>
{
    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await personService.GetAsync(request.Id, cancellationToken);

        var personVacancies = await personVacancyService.GetByPersonIdAsync(request.Id, cancellationToken);
        personVacancyService.DeleteRange(personVacancies);

        var personQuestions = await personQuestionService.GetByPersonIdAsync(request.Id, cancellationToken);
        personQuestionService.DeleteRange(personQuestions);

        await personService.DeleteAsync(person, cancellationToken);

        return Unit.Value;
    }
}
