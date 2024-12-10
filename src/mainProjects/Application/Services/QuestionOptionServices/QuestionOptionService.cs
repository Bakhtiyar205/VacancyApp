using Application.Features.QuestionOptions.Rules;
using Application.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.QuestionOptionServices;
public class QuestionOptionService(IQuestionOptionRepository questionOptionRepository, QuestionOptionRules questionOptionRules) : IQuestionOptionService
{
    #region Command

    public async Task<QuestionOption> CreateAsync(QuestionOption request, CancellationToken cancellationToken = default)
    {
        return await questionOptionRepository.AddAsync(request);
    }

    public async Task DeleteAsync(QuestionOption questionOption, CancellationToken cancellationToken = default)
    {
        questionOption.IsDeleted = true;
        await questionOptionRepository.UpdateAsync(questionOption);
    }

    public async Task DeleteByQuestionAsync(IList<QuestionOption> quesstionOptions, CancellationToken cancellationToken = default)
    {
        foreach (var question in quesstionOptions) question.IsDeleted = true;

        await questionOptionRepository.UpdateRangeAsync(quesstionOptions);
    }

    public async Task<QuestionOption> UpdateAsync(QuestionOption request, CancellationToken cancellationToken = default)
    {
        return await questionOptionRepository.UpdateAsync(request);
    }
    #endregion

    #region Queries
    public async Task<QuestionOption> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await GetValidQuestionOptionAsync(questionOptionRepository, questionOptionRules, id, cancellationToken);
    }

    public async Task<IPaginate<QuestionOption>> GetPaginateAsync(int pageNumber, int pageSize, int questionId = 0, CancellationToken cancellationToken = default)
    {
        return await questionOptionRepository.GetPaginatedListAsync(
               m => (questionId != 0 ? m.QuestionId == questionId && !m.Question.IsDeleted : m.QuestionId == m.QuestionId)  && !m.IsDeleted,
               orderBy: m => m.OrderBy(n => n.QuestionId),
               include: m => m.Include(t => t.Question),
               index: pageNumber, size: pageSize, enableTracking: false, cancellationToken: cancellationToken);
    }
    #endregion

    #region Private methods
    public async Task<QuestionOption> GetValidQuestionOptionAsync(IQuestionOptionRepository questionOptionRepository, QuestionOptionRules questionOptionRules, int id, CancellationToken cancellationToken)
    {
        var questionOption = await questionOptionRepository.GetAsNoTrackingAsync(v => v.Id == id && !v.IsDeleted, cancellationToken: cancellationToken);
        return questionOptionRules.Validate(questionOption);
    }
    #endregion
}
