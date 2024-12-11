using Core.Domain.Dtos;

namespace Application.Features.PersonVacancies.Dto.Person;
public class PersonVacancyForPersonDto : BaseDto
{
    public int VacancyId { get; set; }
    public string? VacancyName { get; set; }
}
