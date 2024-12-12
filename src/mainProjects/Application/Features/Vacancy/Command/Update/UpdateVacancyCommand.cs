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
    public int ExamQuestionCount { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class UpdateVacancyCommandHandler(IVacancyService vacancyService, IMapper mapper) : IRequestHandler<UpdateVacancyCommand, UpdateVacancyDto>
{
    public async Task<UpdateVacancyDto> Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
    {
        var vacancy = await vacancyService.GetAsync(request.Id, cancellationToken);

        vacancy = mapper.Map(request, vacancy);

        vacancy = await vacancyService.UpdateAsync(vacancy, cancellationToken);

        return mapper.Map<UpdateVacancyDto>(vacancy);
    }
}
