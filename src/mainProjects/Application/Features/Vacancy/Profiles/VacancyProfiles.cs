using Application.Features.Vacancies.Command.Create;
using Application.Features.Vacancies.Command.Update;
using Application.Features.Vacancies.Dto;
using Application.Features.Vacancies.Model;
using Application.Features.Vacancies.Dto.PersonVacancy;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Vacancies.Profiles;
public class VacancyProfiles : Profile
{
    public VacancyProfiles()
    {
        CreateMap<Vacancy, GetVacancyDto>();
        CreateMap<Vacancy, VacancyListDto>();
        CreateMap<IPaginate<Vacancy>, VacancyListModel>();
        CreateMap<Vacancy, CreateVacancyDto>();
        CreateMap<Vacancy, UpdateVacancyDto>();

        CreateMap<CreateVacancyCommand, Vacancy>();
        CreateMap<UpdateVacancyCommand, Vacancy>();

        CreateMap<Vacancy, VacancyForPersonDto>();
    }
}
