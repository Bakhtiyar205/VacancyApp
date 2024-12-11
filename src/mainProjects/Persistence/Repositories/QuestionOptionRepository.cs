using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;
internal class QuestionOptionRepository : EfRepositoryBase<QuestionOption, AppDbContext>, IQuestionOptionRepository
{
    public QuestionOptionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<int>> GetIdsByQuestionAsync(int questionId, CancellationToken cancellationToken)
    {
        return await Query().Where(m => m.QuestionId == questionId && !m.IsDeleted).Select(m=> m.Id).ToListAsync();
    }
}
