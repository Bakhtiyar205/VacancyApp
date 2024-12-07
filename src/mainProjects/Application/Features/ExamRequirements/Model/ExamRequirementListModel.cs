using Core.Persistence.Paging;

namespace Application.Features.ExamRequirements.Dto.Model;
public class ExamRequirementListModel : BasePageableModel
{
    public IList<ExamRequiementListDto> Items { get; set; } = [];
}
