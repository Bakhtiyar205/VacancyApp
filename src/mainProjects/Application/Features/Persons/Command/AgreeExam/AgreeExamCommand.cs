using Application.Features.Persons.Rules;
using Application.Services.DateTimeProviders;
using Application.Services.PersonServices;
using Application.Services.VacancyServices;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Persons.Command.AgreeExam    ;
public class AgreeExamCommand : IRequest<bool>
{
    public int PersonId { get; set; }
    public bool IsAgree { get; set; }
    public int VacancyId { get; set; }
    public AgreeExamCommand(int personId, int vacancyId, bool isAgree)
    {
        PersonId = personId;
        IsAgree = isAgree;
        VacancyId = vacancyId;
    }
}

public class AgreeExamCommandHandler(IPersonService personService, IVacancyService vacancyService,PersonRules personRules,IMapper mapper) : IRequestHandler<AgreeExamCommand, bool>
{
    public async Task<bool> Handle(AgreeExamCommand request, CancellationToken cancellationToken)
    {
        personRules.IsAgreeExam(request.IsAgree);
        var person = await personService.GetPersonWithVacancyAsync(request.PersonId, cancellationToken);

        var personVacancy = person.PersonVacancies.FirstOrDefault(x => x.VacancyId == request.VacancyId);
        personRules.IsPersonVacancyExist(personVacancy);

        person.IsParticipated = request.IsAgree;

        await vacancyService.GetAsync(request.VacancyId, cancellationToken);

        person.ExamStartDate = IDateTimeProvider.Now;

        var vacancy = await vacancyService.GetWithQuestionsAsync(request.VacancyId, cancellationToken);
        ExamEndDate(person, vacancy);

        await personService.UpdateAsync(person, cancellationToken);
        return true;
    }

    private void ExamEndDate(Person person, Vacancy vacancy)
    {
        if (vacancy.ExamQuestionCount <= vacancy.Questions.Count())
        {
            person.ExamEndDate = IDateTimeProvider.Now.AddMinutes(vacancy.ExamQuestionCount);
        }
        else
        {
            person.ExamEndDate = IDateTimeProvider.Now.AddMinutes(vacancy.Questions.Count());
        }
    }
}
