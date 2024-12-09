using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;
internal class VacancyRepository : EfRepositoryBase<Vacancy, AppDbContext>, IVacancyRepository
{
    public VacancyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Vacancy?> GetVacancyWithPersonAsync(int vacancyId, CancellationToken cancellationToken = default)
    {
        return await GetAsNoTrackingAsync(p => p.Id == vacancyId, query => query.Include(m => m.PersonVacancies).ThenInclude(m => m.Person));
    }
}
