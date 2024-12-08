using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Services.ExamRequirementServices;
public interface IExamRequirementServices
{
    Task<ExamRequirement> CreateAsync(ExamRequirement request);
    Task DeleteAsync(ExamRequirement examRequirement, CancellationToken cancellationToken = default);
    Task<ExamRequirement> UpdateAsync(ExamRequirement request, CancellationToken cancellationToken = default);
    Task<ExamRequirement> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<IPaginate<ExamRequirement>> GetPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
}
