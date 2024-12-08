using Application.Services.QuestionServices;
using Application.Services.VacancyServices;
using MediatR;

namespace Application.Features.Questions.Command.DeleteByVacancy;
public class DeleteByVacancyCommand(int vacancyId,int size) : IRequest<Unit>
{
    public int VacancyId { get; set; } = vacancyId;
    public int Size { get; set; } = size;
}

public class DeleteByVacancyCommandHandler(IVacancyService vacancyService, IQuestionService questionService) : IRequestHandler<DeleteByVacancyCommand, Unit>
{
    public async Task<Unit> Handle(DeleteByVacancyCommand request, CancellationToken cancellationToken)
    {
        await vacancyService.GetAsync(request.VacancyId, cancellationToken);

        var questionList = await questionService.GetPaginatedAsync(0,request.Size,request.VacancyId, cancellationToken);

        await questionService.DeleteByVacancyAsync(questionList.Items, cancellationToken);

        return Unit.Value;
    }
}
