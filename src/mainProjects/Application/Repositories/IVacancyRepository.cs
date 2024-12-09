using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories;
public interface IVacancyRepository : IAsyncRepository<Vacancy>,
    IRepository<Vacancy>
{
    Task<Vacancy?> GetVacancyWithPersonAsync(int vacancyId, CancellationToken cancellationToken = default);
}
