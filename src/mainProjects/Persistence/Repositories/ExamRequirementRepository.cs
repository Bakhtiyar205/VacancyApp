using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;
internal class ExamRequirementRepository : EfRepositoryBase<ExamRequirement, AppDbContext>, IExamRequirementRepository
{
    public ExamRequirementRepository(AppDbContext context) : base(context)
    {
    }
}
