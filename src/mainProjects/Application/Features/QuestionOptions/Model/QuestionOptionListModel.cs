using Application.Features.QuestionOptions.Dto;
using Core.Persistence.Paging;

namespace Application.Features.QuestionOptions.Model;
public class QuestionOptionListModel : BasePageableModel
{
    public IList<QuestionOptionListDto> Items { get; set; } = [];
}
