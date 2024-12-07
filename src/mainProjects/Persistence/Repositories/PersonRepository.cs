using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;
internal class PersonRepository : EfRepositoryBase<Person, AppDbContext>, IPersonRepository
{
    public PersonRepository(AppDbContext context) : base(context)
    {
    }
}
