using Application.Features.Persons.Model;
using Application.Services.PersonServices;
using AutoMapper;
using MediatR;

namespace Application.Features.Persons.Query.GetList;
public class GetPersonListQuery(int pageNumber, int pageSize, int vacancyId) : IRequest<PersonListModel>
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int VacancyId { get; set; } = vacancyId;
}

public class GetPersonListQueryHandler(IPersonService personService, IMapper mapper) : IRequestHandler<GetPersonListQuery, PersonListModel>
{
    public async Task<PersonListModel> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
    {
        var data = await personService.GetPaginatedAsync(request.PageNumber, request.PageSize, request.VacancyId, cancellationToken);

        return mapper.Map<PersonListModel>(data);
    }
}
