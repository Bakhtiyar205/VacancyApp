﻿using Application.Features.Persons.Rules;
using Application.Features.Vacancies.Rules;
using Application.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.VacancyServices;
public class VacancyService(IVacancyRepository vacancyRepository, VacancyRules vacancyRules) : IVacancyService
{
    #region Command
    public async Task<Vacancy> CreateAsync(Vacancy request, CancellationToken cancellationToken = default)
    {
        await CheckAnotherValidVacancyAsync(request.Title, cancellationToken: cancellationToken);

        var vacancy = await vacancyRepository.AddAsync(request);

        return vacancy;
    }

    public async Task DeleteAsync(Vacancy vacancy, CancellationToken cancellationToken = default)
    {
        vacancy.IsDeleted = true;
        await vacancyRepository.UpdateAsync(vacancy);
    }

    public async Task<Vacancy> UpdateAsync(Vacancy request, CancellationToken cancellationToken = default)
    {
        await CheckAnotherValidVacancyAsync(request.Title, request.Id, cancellationToken);

        return await vacancyRepository.UpdateAsync(request);

    }
    #endregion

    #region Queries
    public async Task<Vacancy> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var vacancy = await vacancyRepository.GetAsNoTrackingAsync(v => v.Id == id && !v.IsDeleted, cancellationToken: cancellationToken);

        return vacancyRules.Validate(vacancy);
    }

    public async Task<Vacancy> GetWithQuestionsAsync(int id, CancellationToken cancellationToken = default)
    {
        var vacancy = await vacancyRepository
            .GetAsNoTrackingAsync(v=>v.Id == id && !v.IsDeleted, c => c.Include(m=>m.Questions.Where(t=>!t.IsDeleted)), cancellationToken);

        return vacancyRules.Validate(vacancy);
    }

    public async Task<IPaginate<Vacancy>> GetPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        return await vacancyRepository.GetPaginatedListAsync(m => !m.IsDeleted,
               index: pageNumber, size: pageSize, enableTracking: false, cancellationToken: cancellationToken);
    }

    public async Task<Vacancy> GetVacancyWithPersonAsync(int id, CancellationToken cancellationToken = default)
    {
        var vacancy = await vacancyRepository.GetVacancyWithPersonAsync(id, cancellationToken);
        return vacancyRules.Validate(vacancy);
    }

    #endregion

    #region Private methods
    private async Task CheckAnotherValidVacancyAsync(string title, int? id = null, CancellationToken cancellationToken = default)
    {
        var vacancy = await vacancyRepository.GetAsNoTrackingAsync(v => (id != null ? v.Id != id : v.Id == v.Id)
                            && v.Title == title && !v.IsDeleted, cancellationToken: cancellationToken);

        vacancyRules.CheckExistence(vacancy);
    }
    #endregion
}
