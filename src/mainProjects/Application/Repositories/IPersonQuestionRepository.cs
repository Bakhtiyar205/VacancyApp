using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories;
public interface IPersonQuestionRepository : IAsyncRepository<PersonQuestion>,
    IRepository<PersonQuestion>
{
}
