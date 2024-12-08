using Core.Domain.Dtos;

namespace Application.Features.ExamRequirements.Dto;
public class UpdateExamRequirementDto : BaseDto
{
    public string? Detail { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
