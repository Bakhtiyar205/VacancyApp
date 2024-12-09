using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Services.PersonServices;
public interface IPersonService
{
    Task<Person> CreateAsync(Person request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Person person, CancellationToken cancellationToken = default);
    Task<Person> UpdateAsync(Person request, CancellationToken cancellationToken = default);
    Task<Person> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<Person> GetPersonWithVacancyAsync(int id, CancellationToken cancellationToken = default);
    Task<IPaginate<Person>> GetPaginatedAsync(int pageNumber, int pageSize, int vacancyId = 0, CancellationToken cancellationToken = default);
}
