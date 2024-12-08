using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Services.QuestionServices;
public interface IQuestionService
{
    Task<Question> CreateAsync(Question request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Question question, CancellationToken cancellationToken = default);
    Task<Question> UpdateAsync(Question request, CancellationToken cancellationToken = default);
    Task<Question> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<IPaginate<Question>> GetPaginatedAsync(int pageNumber, int pageSize,int vacancyId, CancellationToken cancellationToken = default);
}
