using Core.Domain.Dtos;

namespace Application.Features.ExamRequirements.Dto;
public class CreateExamRequirementDto : BaseDto
{
    public string? Detail { get; set; }
    public DateTime CreatedDate { get; set; }
}
