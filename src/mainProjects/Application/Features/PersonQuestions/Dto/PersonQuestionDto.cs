using Application.Features.Questions.Dto.ForPersonQuestion;
using Core.Domain.Dtos;

namespace Application.Features.PersonQuestions.Dto;
public class PersonQuestionDto : BaseDto
{
    public int QuestionId { get; set; }
    public QuestionForPersonDto? Question { get; set; }
}
