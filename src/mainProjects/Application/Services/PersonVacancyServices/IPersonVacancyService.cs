using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Services.PersonVacancyServices;
public interface IPersonVacancyService
{
    Task<PersonVacancy> CreateAsync(PersonVacancy personVacancy, CancellationToken cancellationToken = default);
    void DeleteRange(IList<PersonVacancy> personVacancies);
    Task<IList<PersonVacancy>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken = default);
    Task<IList<PersonVacancy>> GetByVacancyIdAsync(int vacancyId, CancellationToken cancellationToken = default);
}
