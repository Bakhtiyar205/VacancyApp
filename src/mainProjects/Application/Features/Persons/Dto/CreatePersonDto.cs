﻿using Core.Domain.Dtos;

namespace Application.Features.Persons.Dto;
public class CreatePersonDto : BaseDto
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int VacancyId { get; set; }
    public string? VacancyName { get; set; }
    public DateTime? CreatedDate { get; set; }
}
