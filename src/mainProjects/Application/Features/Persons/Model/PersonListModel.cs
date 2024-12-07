using Application.Features.Persons.Dto;
using Core.Persistence.Paging;

namespace Application.Features.Persons.Model;
public class PersonListModel : BasePageableModel
{
    public IList<PersonListDto> Items { get; set; } = [];
}
