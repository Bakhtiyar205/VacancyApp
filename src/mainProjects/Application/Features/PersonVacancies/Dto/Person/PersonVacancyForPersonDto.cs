using Application.Features.Vacancies.Dto.PersonVacancy;
using Core.Domain.Dtos;

namespace Application.Features.PersonVacancies.Dto.Person;
public class PersonVacancyForPersonDto : BaseDto
{
    public VacancyForPersonDto? Vacancy { get; set; }
}
