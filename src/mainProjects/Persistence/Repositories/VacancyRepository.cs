using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;
internal class VacancyRepository : EfRepositoryBase<Vacancy, AppDbContext>, IVacancyRepository
{
    public VacancyRepository(AppDbContext context) : base(context)
    {
    }
}
