using Core.Domain.Dtos;

namespace Application.Features.Questions.Dto;
public class QuestionListDto : BaseDto
{
    public string? QuestionDetail { get; set; }
    public string? VacancyName { get; set; }
    public int VacancyId { get; set; }
}
