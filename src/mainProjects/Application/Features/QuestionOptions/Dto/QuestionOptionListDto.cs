using Core.Domain.Dtos;

namespace Application.Features.QuestionOptions.Dto;
public class QuestionOptionListDto : BaseDto
{
    public string? Option { get; set; }
    public int QuestionId { get; set; }
    public string? QuestionName { get; set; }

}
