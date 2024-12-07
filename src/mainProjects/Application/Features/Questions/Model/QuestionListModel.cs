using Application.Features.Questions.Dto;
using Core.Persistence.Paging;

namespace Application.Features.Questions.Model;
public class QuestionListModel : BasePageableModel
{
    public IList<QuestionListDto> Items { get; set; } = [];
}
