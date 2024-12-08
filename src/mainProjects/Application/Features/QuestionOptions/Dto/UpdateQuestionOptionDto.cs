using Core.Domain.Dtos;

namespace Application.Features.QuestionOptions.Dto;
public class UpdateQuestionOptionDto : BaseDto
{
    public string? Option { get; set; }
    public bool IsAnswer { get; set; }
    public int QuestionId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
