﻿using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Threading;

namespace Persistence.Repositories;
internal class QuestionRepository : EfRepositoryBase<Question, AppDbContext>, IQuestionRepository
{
    public QuestionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IList<Question>> GetQuestionsByVacancyIdAsync(int vacancyId, int examQuestionCount,CancellationToken cancellationToken)
    {
       return await Query().Where(m => m.VacancyId == vacancyId && !m.IsDeleted)
            .OrderBy(x=> Guid.NewGuid()).Take(examQuestionCount)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
