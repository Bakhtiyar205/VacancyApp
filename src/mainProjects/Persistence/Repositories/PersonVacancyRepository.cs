using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;
internal class PersonVacancyRepository : EfRepositoryBase<PersonVacancy, AppDbContext>, IPersonVacancyRepository
{
    public PersonVacancyRepository(AppDbContext context) : base(context)
    {
    }
}
