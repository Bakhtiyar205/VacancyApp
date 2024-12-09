using Core.Domain.Dtos;

namespace Application.Features.Vacancies.Dto.PersonVacancy;
public class VacancyForPersonDto : BaseDto
{
    public string Title { get; set; } = default!;
}
