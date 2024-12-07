using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories;
public interface IExamRequirementRepository : IAsyncRepository<ExamRequirement>,
    IRepository<ExamRequirement>
{
}
