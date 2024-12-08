using Core.Domain.Dtos;

namespace Application.Features.Vacancies.Dto;
public class GetVacancyDto : BaseDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
