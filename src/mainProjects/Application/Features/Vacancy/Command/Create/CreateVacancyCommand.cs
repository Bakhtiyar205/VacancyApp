using Application.Features.Vacancies.Dto;
using Application.Services.VacancyServices;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Vacancies.Command.Create;
public class CreateVacancyCommand : IRequest<CreateVacancyDto>
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class CreateVacancyCommmandHandler(IVacancyService vacancyService, IMapper mapper) : IRequestHandler<CreateVacancyCommand, CreateVacancyDto>
{
    public async Task<CreateVacancyDto> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
    {
        var vacancy = mapper.Map<Vacancy>(request);

        vacancy = await vacancyService.CreateAsync(vacancy);

        return mapper.Map<CreateVacancyDto>(vacancy);
    }
}
