using Application.Features.Vacancies.Dto;
using Application.Services.VacancyServices;
using AutoMapper;
using MediatR;

namespace Application.Features.Vacancies.Query.GetById;
public class GetVacancyByIdQuery(int id) : IRequest<GetVacancyDto>
{
    public int Id { get; set; } = id;
}

public class GetVacancyByIdQueryHandler(IVacancyService vacancyService, IMapper mapper) : IRequestHandler<GetVacancyByIdQuery, GetVacancyDto>
{
    public async Task<GetVacancyDto> Handle(GetVacancyByIdQuery request, CancellationToken cancellationToken)
    {
        var vacancy = await vacancyService.GetAsync(request.Id, cancellationToken);

        return mapper.Map<GetVacancyDto>(vacancy);
    }
}
