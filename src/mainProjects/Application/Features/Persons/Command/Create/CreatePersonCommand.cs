using Application.Features.Persons.Dto;
using Application.Services.PersonServices;
using Application.Services.PersonVacancyServices;
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

public class CreatePersonCommandHandler(IPersonService personService, IVacancyService vacancyService, IPersonVacancyService personVacancyService, IMapper mapper) 
            : IRequestHandler<CreatePersonCommand, CreatePersonDto>
{
    public async Task<CreatePersonDto> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        await vacancyService.GetAsync(request.VacancyId, cancellationToken);

        var person = mapper.Map<Person>(request);

        person = await personService.CreateAsync(person, cancellationToken);

        await personVacancyService.CreateAsync(new PersonVacancy { PersonId = person.Id, VacancyId = request.VacancyId }, cancellationToken);

        var personDto = mapper.Map<CreatePersonDto>(person);
        personDto.VacancyId = request.VacancyId;

        return personDto;
    }
}
