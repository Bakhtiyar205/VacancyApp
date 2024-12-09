using Application.Features.Persons.Dto.PersonVacancy;
using Core.Domain.Dtos;

namespace Application.Features.PersonVacancies.Dto.Vacancy;
public class PersonVacancyForVacancyDto : BaseDto
{
    public PersonForVacancyDto? Person { get; set; }
}
