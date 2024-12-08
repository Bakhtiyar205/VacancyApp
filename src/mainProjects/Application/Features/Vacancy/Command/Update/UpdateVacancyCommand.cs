using Application.Features.Vacancies.Dto;
using Application.Services.VacancyServices;
using AutoMapper;
using MediatR;

namespace Application.Features.Vacancies.Command.Update;
public class UpdateVacancyCommand : IRequest<UpdateVacancyDto>
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class UpdateVacancyCommandHandler(IVacancyService vacancyService, IMapper mapper) : IRequestHandler<UpdateVacancyCommand, UpdateVacancyDto>
{
    private readonly IVacancyService _vacancyService = vacancyService;
    private readonly IMapper _mapper = mapper;

    public async Task<UpdateVacancyDto> Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
    {
        var vacancy = await _vacancyService.GetAsync(request.Id, cancellationToken);

        vacancy = _mapper.Map(request, vacancy);

        vacancy = await _vacancyService.UpdateAsync(vacancy, cancellationToken);

        return _mapper.Map<UpdateVacancyDto>(vacancy);
    }
}
