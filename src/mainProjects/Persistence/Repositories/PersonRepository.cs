using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;
internal class PersonRepository : EfRepositoryBase<Person, AppDbContext>, IPersonRepository
{
    public PersonRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Person?> GetPersonWithVacancy(int personId, CancellationToken cancellationToken = default)
    {
        return await GetAsNoTrackingAsync(p => p.Id == personId, query => query.Include(m=> m.PersonVacancies).ThenInclude(m=>m.Vacancy));
    }
}
