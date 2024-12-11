using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Services.VacancyServices;
public interface IVacancyService
{
    Task<Vacancy> CreateAsync(Vacancy request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Vacancy vacancy, CancellationToken cancellationToken = default);
    Task<Vacancy> UpdateAsync(Vacancy request, CancellationToken cancellationToken = default);
    Task<Vacancy> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<Vacancy> GetVacancyWithPersonAsync(int id, CancellationToken cancellationToken = default);
    Task<Vacancy> GetWithQuestionsAsync(int id, CancellationToken cancellationToken = default);
    Task<IPaginate<Vacancy>> GetPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
}
