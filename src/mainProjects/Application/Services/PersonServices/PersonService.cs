using Application.Features.Persons.Rules;
using Application.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Services.PersonServices;
public class PersonService(IPersonRepository personRepository, PersonRules personRules) : IPersonService
{
    #region Command
    public async Task<Person> CreateAsync(Person request, CancellationToken cancellationToken = default)
    {
        await CheckAnotherValidPersonAsync(request.Email, cancellationToken: cancellationToken);
        var person = await personRepository.AddAsync(request);
        return person;
    }
    public async Task DeleteAsync(Person person, CancellationToken cancellationToken = default)
    {
        person.IsDeleted = true;
        await personRepository.UpdateAsync(person);
    }
    public async Task<Person> UpdateAsync(Person request, CancellationToken cancellationToken = default)
    {
        await CheckAnotherValidPersonAsync(request.Email, request.Id, cancellationToken);
        return await personRepository.UpdateAsync(request);
    }
    #endregion
    #region Queries
    public async Task<Person> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await GetValidPersonAsync(id, cancellationToken);
    }

    public async Task<Person> GetPersonWithVacancyAsync(int id, CancellationToken cancellationToken = default)
    {
        var person = await personRepository.GetPersonWithVacancy(id, cancellationToken);
        return personRules.Validate(person);
    }
    public async Task<IPaginate<Person>> GetPaginatedAsync(int pageNumber, int pageSize, int vacancyId = 0, CancellationToken cancellationToken = default)
    {
        return await personRepository.GetPaginatedListAsync(m => !m.IsDeleted && (vacancyId != 0 ? m.PersonVacancies.Any(x => x.VacancyId == vacancyId) : m.PersonVacancies == m.PersonVacancies),
               index: pageNumber, size: pageSize, enableTracking: false, cancellationToken: cancellationToken);
    }
    #endregion
    #region Private methods
    private async Task<Person> GetValidPersonAsync(int id, CancellationToken cancellationToken = default)
    {
        var person = await personRepository.GetAsNoTrackingAsync(v => v.Id == id && !v.IsDeleted, cancellationToken: cancellationToken);
        return personRules.Validate(person);
    }
    private async Task CheckAnotherValidPersonAsync(string email, int? id = null, CancellationToken cancellationToken = default)
    {
        var person = await personRepository.GetAsNoTrackingAsync(v => (id != null ? v.Id != id : v.Id == v.Id)
                            && v.Email == email && !v.IsDeleted, cancellationToken: cancellationToken);
        personRules.CheckExistence(person);
    }
    #endregion
}
