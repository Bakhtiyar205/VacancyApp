using Application.Features.ExamRequirements.Dto;
using Core.Persistence.Paging;

namespace Application.Features.ExamRequirements.Model;
public class ExamRequirementListModel : BasePageableModel
{
    public IList<ExamRequiementListDto?> Items { get; set; } = [];
}
