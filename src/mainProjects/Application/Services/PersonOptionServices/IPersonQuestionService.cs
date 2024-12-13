using Domain.Entities;

namespace Application.Services.PersonQuestionServices;
public interface IPersonQuestionService
{
    Task<PersonQuestion> CreateAsync(PersonQuestion personVacancy, CancellationToken cancellationToken = default);
    IEnumerable<PersonQuestion> CreateRange(IList<PersonQuestion> personVacancies);
    Task UpdateAsync(PersonQuestion personVacancy, CancellationToken cancellationToken = default);
    void DeleteRange(IList<PersonQuestion> personVacancies);

    Task<PersonQuestion> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IList<PersonQuestion>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken = default);
    Task<IList<PersonQuestion>> GetByQuestionIdAsync(int questionId, CancellationToken cancellationToken = default);
    Task<IList<PersonQuestion>> GetListByPersonVacancyIdAsync(int personId, int vacancyId, CancellationToken cancellationToken = default);
    Task<IList<PersonQuestion>> GetPersonIdAsync(int person, CancellationToken cancellationToken);
}
