using Core.Domain.Dtos;

namespace Application.Features.Questions.Dto;
public class CreateQuestionDto : BaseDto
{
    public string? QuestionDetail { get; set; }
    public int VacancyId { get; set; }
    public int OptionCount { get; set; }
    public DateTime? CreatedDate { get; set; }
}
