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

    public async Task<IPaginate<Question>> GetPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        return await questionRepository.GetPaginatedListAsync(m => !m.IsDeleted,
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
