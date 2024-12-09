using Application.Features.PersonVacancies.Dto.Person;
using Application.Features.PersonVacancies.Dto.Vacancy;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.PersonVacancies.Profiles;
public class PersonVacancyProfiles : Profile
{
    public PersonVacancyProfiles()
    {
        CreateMap<PersonVacancy, PersonVacancyForPersonDto>();

        CreateMap<PersonVacancy, PersonVacancyForVacancyDto>();
    }
}
