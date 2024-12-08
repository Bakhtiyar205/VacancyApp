using Application.Services.VacancyServices;
using MediatR;

namespace Application.Features.Vacancies.Command.Delete;
public class DeleteVacancyCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}

public class DeleteVacancyCommandHandler(IVacancyService vacancyService) : IRequestHandler<DeleteVacancyCommand, Unit>
{
    public async Task<Unit> Handle(DeleteVacancyCommand request, CancellationToken cancellationToken)
    {
        var vacancy = await vacancyService.GetAsync(request.Id, cancellationToken);

        await vacancyService.DeleteAsync(vacancy, cancellationToken);

        return Unit.Value;
    }
}
