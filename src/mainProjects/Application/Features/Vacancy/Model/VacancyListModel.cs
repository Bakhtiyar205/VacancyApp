using Application.Features.Vacancies.Dto;
using Core.Persistence.Paging;

namespace Application.Features.Vacancies.Model;
public class VacancyListModel : BasePageableModel
{
    public IList<VacancyListDto> Items { get; set; } = [];
}
