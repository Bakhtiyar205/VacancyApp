using Application.Features.QuestionOptions.Dto.ForPersonQuestion;
using Core.Domain.Dtos;

namespace Application.Features.Questions.Dto.ForPersonQuestion;
public class QuestionForPersonDto : BaseDto
{
    public string? QuestionDetail { get; set; }
    public IList<OptionForPersonDto> QuestionOptions { get; set; } = new List<OptionForPersonDto>();
}
