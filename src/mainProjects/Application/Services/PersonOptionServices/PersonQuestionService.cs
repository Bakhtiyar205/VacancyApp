﻿using Application.Features.PersonQuestions.Rules;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.PersonQuestionServices;
public class PersonQuestionService(IPersonQuestionRepository personQuestionRepository, PersonQuestionRule personQuestionRule) : IPersonQuestionService
{
    #region Commands
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

    public async Task UpdateAsync(PersonQuestion personVacancy, CancellationToken cancellationToken = default)
    {
        await personQuestionRepository.UpdateAsync(personVacancy);
    }
    #endregion

    #region Queries

    public async Task<PersonQuestion> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var data = await personQuestionRepository.GetAsync(m=>m.Id == id);
        return personQuestionRule.Validate(data);
    }

    public async Task<IList<PersonQuestion>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken = default)
    {
        return await personQuestionRepository.GetListAsync(pv => pv.PersonId == personId, enableTracking: false, cancellationToken: cancellationToken);
    }

    public async Task<IList<PersonQuestion>> GetByQuestionIdAsync(int questionId, CancellationToken cancellationToken = default)
    {
        return await personQuestionRepository.GetListAsync(pv => pv.QuestionId == questionId, enableTracking: false, cancellationToken: cancellationToken);
    }

    public async Task<IList<PersonQuestion>> GetPersonIdAsync(int person, CancellationToken cancellationToken)
    {
        return await personQuestionRepository.GetListAsync(pv => pv.PersonId == person, cancellationToken: cancellationToken);
    }

    public async Task<IList<PersonQuestion>> GetListByPersonVacancyIdAsync(int personId, int vacancyId, CancellationToken cancellationToken = default)
    {
        return  await personQuestionRepository
                .GetListAsync(pv => pv.PersonId == personId && pv.VacancyId == vacancyId, 
                          include: m=>m.Include(x=>x.Question).ThenInclude(y=>y.QuestionOptions.Where(c=>!c.IsDeleted)), 
                          enableTracking: false, cancellationToken: cancellationToken);
    }
    #endregion
}
