using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories;
public interface IQuestionRepository :  IAsyncRepository<Question>,
    IRepository<Question>
{
    Task<IList<Question>> GetQuestionsByVacancyIdAsync(int vacancyId, int examQuestionCount, CancellationToken cancellationToken);
}
