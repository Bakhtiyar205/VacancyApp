using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories;
public interface IQuestionOptionRepository : IAsyncRepository<QuestionOption>,
    IRepository<QuestionOption>
{
}
