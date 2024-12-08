using Application.Features.Questions.Rules;
using Application.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Services.QuestionServices;
public class QuestionService(IQuestionRepository questionRepository, QuestionRules questionRules) : IQuestionService
{
    #region Commands
    public async Task<Question> CreateAsync(Question request, CancellationToken cancellationToken = default)
    {
        return await questionRepository.AddAsync(request);
    }

    public async Task DeleteAsync(Question question, CancellationToken cancellationToken = default)
    {
        question.IsDeleted = true;
        await questionRepository.UpdateAsync(question);
    }

    public async Task DeleteByVacancyAsync(IList<Question> questions, CancellationToken cancellationToken = default) 
    {
        foreach (var question in questions) question.IsDeleted = true;

        await questionRepository.UpdateRangeAsync(questions);
    }

    public async Task<Question> UpdateAsync(Question request, CancellationToken cancellationToken = default)
    {
        return await questionRepository.UpdateAsync(request);
    }
    #endregion

    #region Queries
    public async Task<Question> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await GetValidQuestionAsync(questionRepository, questionRules, id, cancellationToken);
    }

    public async Task<IPaginate<Question>> GetPaginatedAsync(int pageNumber, int pageSize, int vacancyId, CancellationToken cancellationToken = default)
    {
        return await questionRepository.GetPaginatedListAsync(
               m => (vacancyId != 0 ? m.VacancyId == vacancyId && !m.Vacancy.IsDeleted : m.VacancyId == m.VacancyId) && !m.IsDeleted,
               index: pageNumber, size: pageSize, enableTracking: false, cancellationToken: cancellationToken);
    }
    #endregion

    #region Private methods

    private static async Task<Question> GetValidQuestionAsync(IQuestionRepository questionRepository, QuestionRules questionRules, int id, CancellationToken cancellationToken)
    {
        var question = await questionRepository.GetAsNoTrackingAsync(v => v.Id == id && !v.IsDeleted, cancellationToken: cancellationToken);

        return questionRules.Validate(question);
    }
    #endregion
}
