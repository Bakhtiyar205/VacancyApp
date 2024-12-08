using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Services.QuestionOptionServices;

public interface IQuestionOptionService
{
    Task<QuestionOption> CreateAsync(QuestionOption request, CancellationToken cancellationToken = default);
    Task DeleteAsync(QuestionOption questionOption, CancellationToken cancellationToken = default);
    Task DeleteByQuestionAsync(IList<QuestionOption> quesstionOptions, CancellationToken cancellationToken = default);
    Task<QuestionOption> UpdateAsync(QuestionOption request, CancellationToken cancellationToken = default);
    Task<QuestionOption> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<IPaginate<QuestionOption>> GetPaginateAsync(int pageNumber, int pageSize, int questionId = 0, CancellationToken cancellationToken = default);
}