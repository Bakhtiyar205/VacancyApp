using Application.Features.PersonVacancies.Dto.Person;
using Application.Features.PersonVacancies.Dto.Vacancy;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.PersonVacancies.Profiles;
public class PersonVacancyProfiles : Profile
{
    public PersonVacancyProfiles()
    {
        CreateMap<PersonVacancy, PersonVacancyForPersonDto>()
            .ForMember(m => m.VacancyName, opt => opt.MapFrom(src => src.Vacancy.Title));

        CreateMap<PersonVacancy, PersonVacancyForVacancyDto>();
    }
}
