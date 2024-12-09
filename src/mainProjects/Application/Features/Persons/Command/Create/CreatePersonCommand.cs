using Application.Features.Persons.Dto;
using Application.Services.PersonQuestionServices;
using Application.Services.PersonServices;
using Application.Services.PersonVacancyServices;
using Application.Services.QuestionServices;
using Application.Services.VacancyServices;
using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Persons.Command.Create;
public class CreatePersonCommand : IRequest<CreatePersonDto>, ITransactionalRequest
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public int VacancyId { get; set; }
}

public class CreatePersonCommandHandler(IPersonService personService, IVacancyService vacancyService, IPersonVacancyService personVacancyService, IPersonQuestionService personQuestionService, IQuestionService questionService, IMapper mapper)
            : IRequestHandler<CreatePersonCommand, CreatePersonDto>
{
    public async Task<CreatePersonDto> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var vacancy = await vacancyService.GetAsync(request.VacancyId, cancellationToken);

        var person = mapper.Map<Person>(request);

        person = await personService.CreateAsync(person, cancellationToken);

        await personVacancyService.CreateAsync(new PersonVacancy { PersonId = person.Id, VacancyId = request.VacancyId }, cancellationToken);

        await CreatePersonVacancyList(personQuestionService, questionService, vacancy, person, cancellationToken);

        var personDto = mapper.Map<CreatePersonDto>(person);
        personDto.VacancyId = request.VacancyId;

        return personDto;
    }

    private async Task CreatePersonVacancyList(IPersonQuestionService personQuestionService, IQuestionService questionService, Vacancy vacancy, Person person, CancellationToken cancellationToken)
    {
        var questionList = await questionService.GetQuestionForPerson(vacancy.Id, vacancy.ExamQuestionCount, cancellationToken);

        var personQuestion = questionList.Select(x => new PersonQuestion { PersonId = person.Id, QuestionId = x.Id }).ToList();

        personQuestionService.CreateRange(personQuestion);
    }
}
