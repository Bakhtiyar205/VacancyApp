using Application.Features.PersonVacancies.Dto.Person;
using Core.Domain.Dtos;

namespace Application.Features.Persons.Dto;
public class GetPersonDto : BaseDto
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? CvPath { get; set; }
    public IList<PersonVacancyForPersonDto> PersonVacancies { get; set; } = new List<PersonVacancyForPersonDto>();
}
