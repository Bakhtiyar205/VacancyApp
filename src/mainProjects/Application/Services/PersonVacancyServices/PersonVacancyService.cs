using Application.Repositories;
using Domain.Entities;

namespace Application.Services.PersonVacancyServices;
public class PersonVacancyService(IPersonVacancyRepository personVacancyRepository) : IPersonVacancyService
{
    public async Task<PersonVacancy> CreateAsync(PersonVacancy personVacancy, CancellationToken cancellationToken = default)
    {
        return await personVacancyRepository.AddAsync(personVacancy);
    }

    public void DeleteRange(IList<PersonVacancy> personVacancies)
    {
        personVacancyRepository.DeleteRange(personVacancies);
    }

    public async Task<IList<PersonVacancy>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken = default)
    {
        return await personVacancyRepository.GetListAsync(pv => pv.PersonId == personId, enableTracking: false, cancellationToken: cancellationToken);
    }

    public async Task<IList<PersonVacancy>> GetByVacancyIdAsync(int vacancyId, CancellationToken cancellationToken = default)
    {
        return await personVacancyRepository.GetListAsync(pv => pv.VacancyId == vacancyId, enableTracking: false, cancellationToken: cancellationToken);
    }
}
