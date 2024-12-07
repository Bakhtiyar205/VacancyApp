using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;
internal class QuestionRepository : EfRepositoryBase<Question, AppDbContext>, IQuestionRepository
{
    public QuestionRepository(AppDbContext context) : base(context)
    {
    }
}
