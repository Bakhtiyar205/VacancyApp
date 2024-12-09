using Application.Features.Questions.Rules;
using Application.Services.PersonQuestionServices;
using Application.Services.PersonVacancyServices;
using Application.Services.QuestionServices;
using Application.Services.VacancyServices;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Vacancies.Command.Delete;
public class DeleteVacancyCommand(int id) : IRequest<Unit>, ITransactionalRequest
{
    public int Id { get; set; } = id;
}

public class DeleteVacancyCommandHandler(IVacancyService vacancyService, IQuestionService questionService, IPersonVacancyService personVacancyService, QuestionRules questionRules) : IRequestHandler<DeleteVacancyCommand, Unit>
{
    public async Task<Unit> Handle(DeleteVacancyCommand request, CancellationToken cancellationToken)
    {
        var vacancy = await vacancyService.GetAsync(request.Id, cancellationToken);

        var questionList = await questionService.GetPaginatedAsync(0, 1, request.Id, cancellationToken);

        questionRules.CheckList(questionList.Items, Questions.Constant.QuestionMessages.VacancyQuestionNotNull);

        var personVacancies = await personVacancyService.GetByVacancyIdAsync(request.Id, cancellationToken);
        personVacancyService.DeleteRange(personVacancies);

        await vacancyService.DeleteAsync(vacancy, cancellationToken);

        return Unit.Value;
    }
}
