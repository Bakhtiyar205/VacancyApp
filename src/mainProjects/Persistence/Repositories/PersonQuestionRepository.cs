using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;
internal class PersonQuestionRepository : EfRepositoryBase<PersonQuestion, AppDbContext>, IPersonQuestionRepository
{
    public PersonQuestionRepository(AppDbContext context) : base(context)
    {
    }
}
