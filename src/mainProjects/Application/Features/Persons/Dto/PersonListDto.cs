using Core.Domain.Dtos;

namespace Application.Features.Persons.Dto;
public class PersonListDto : BaseDto
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}
