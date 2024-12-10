﻿using Application.Repositories;
using Domain.Entities;

namespace Application.Services.PersonQuestionServices;
public class PersonQuestionService(IPersonQuestionRepository personQuestionRepository) : IPersonQuestionService
{
    public async Task<PersonQuestion> CreateAsync(PersonQuestion personVacancy, CancellationToken cancellationToken = default)
    {
        return await personQuestionRepository.AddAsync(personVacancy);
    }

    public IEnumerable<PersonQuestion> CreateRange(IList<PersonQuestion> personVacancies)
    {
        return personQuestionRepository.AddRange(personVacancies);
    }

    public void DeleteRange(IList<PersonQuestion> personVacancies)
    {
        personQuestionRepository.DeleteRange(personVacancies);
    }

    public async Task<IList<PersonQuestion>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken = default)
    {
        return await personQuestionRepository.GetListAsync(pv => pv.PersonId == personId, enableTracking: false, cancellationToken: cancellationToken);
    }

    public async Task<IList<PersonQuestion>> GetByQuestionIdAsync(int questionId, CancellationToken cancellationToken = default)
    {
        return await personQuestionRepository.GetListAsync(pv => pv.QuestionId == questionId, enableTracking: false, cancellationToken: cancellationToken);
    }
}