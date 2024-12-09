using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories;
public interface IPersonRepository : IAsyncRepository<Person>,
    IRepository<Person>
{
    Task<Person?> GetPersonWithVacancy(int personId, CancellationToken cancellationToken = default);
}
