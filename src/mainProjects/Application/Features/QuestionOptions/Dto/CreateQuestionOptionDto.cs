using Core.Domain.Dtos;

namespace Application.Features.QuestionOptions.Dto;
public class CreateQuestionOptionDto : BaseDto
{
    public string? Option { get; set; }
    public bool IsAnswer { get; set; }
    public int QuestionId { get; set; }
    public DateTime? CreatedDate { get; set; }
}
