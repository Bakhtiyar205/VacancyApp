using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;
internal class QuestionOptionRepository : EfRepositoryBase<QuestionOption, AppDbContext>, IQuestionOptionRepository
{
    public QuestionOptionRepository(AppDbContext context) : base(context)
    {
    }
}
