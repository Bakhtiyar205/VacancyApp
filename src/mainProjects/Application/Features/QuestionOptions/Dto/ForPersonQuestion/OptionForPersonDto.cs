using Core.Domain.Dtos;

namespace Application.Features.QuestionOptions.Dto.ForPersonQuestion;
public class OptionForPersonDto : BaseDto
{
    public string? Option { get; set; }
    public bool IsAnswer { get; set; }
}
