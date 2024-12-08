using Application.Features.ExamRequirements.Rules;
using Application.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Services.ExamRequirementServices;
public class ExamRequirementService(IExamRequirementRepository examRequirementRepository, ExamRequirementRules examRequirementRules) : IExamRequirementServices
{
    #region Commands
    public async Task<ExamRequirement> CreateAsync(ExamRequirement request)
    {
        return await examRequirementRepository.AddAsync(request);
    }

    public async Task DeleteAsync(ExamRequirement examRequirement, CancellationToken cancellationToken = default)
    {
        examRequirement.IsDeleted = true;
        await examRequirementRepository.UpdateAsync(examRequirement);
    }

    public async Task<ExamRequirement> UpdateAsync(ExamRequirement request, CancellationToken cancellationToken = default)
    {
        return await examRequirementRepository.UpdateAsync(request);
    }
    #endregion

    #region Queries
    public async Task<ExamRequirement> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await GetValidExamRequirementAsync(id, cancellationToken);
    }

    public async Task<IPaginate<ExamRequirement>> GetPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        return await examRequirementRepository.GetPaginatedListAsync(predicate: m => !m.IsDeleted,
               index: pageNumber, size: pageSize, enableTracking: false, cancellationToken: cancellationToken);
    }
    #endregion

    #region Private Methods
    private async Task<ExamRequirement> GetValidExamRequirementAsync(int id, CancellationToken cancellationToken)
    {
        var examRequirement = await examRequirementRepository.GetAsNoTrackingAsync(m => m.Id == id
                              && !m.IsDeleted, cancellationToken: cancellationToken);

        examRequirement = examRequirementRules.Validate(examRequirement);

        return examRequirement;
    }
    #endregion
}
