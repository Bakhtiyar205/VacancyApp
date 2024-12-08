using Core.Domain.Dtos;

namespace Application.Features.ExamRequirements.Dto;
public class GetExamRequirementDto : BaseDto
{
    public string? Detail { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
