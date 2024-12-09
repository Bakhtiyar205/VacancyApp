using Core.Domain.Dtos;

namespace Application.Features.Persons.Dto.PersonVacancy;
public class PersonForVacancyDto : BaseDto
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
}
