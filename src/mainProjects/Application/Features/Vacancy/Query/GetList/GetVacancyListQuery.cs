using Application.Features.Vacancies.Model;
using Application.Services.VacancyServices;
using AutoMapper;
using MediatR;

namespace Application.Features.Vacancies.Query.GetList;
public class GetVacancyListQuery(int pageNumber, int pageSize) : IRequest<VacancyListModel>
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
}

public class GetVacancyListQueryHandler(IVacancyService vacancyService, IMapper mapper) : IRequestHandler<GetVacancyListQuery, VacancyListModel>
{
    public async Task<VacancyListModel> Handle(GetVacancyListQuery request, CancellationToken cancellationToken)
    {
        var paginated = await vacancyService.GetPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);
        
        return mapper.Map<VacancyListModel>(paginated);
    }
}
