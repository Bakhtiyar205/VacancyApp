using Application.Features.Questions.Dto;
using Application.Services.QuestionServices;
using Application.Services.VacancyServices;
using AutoMapper;
using MediatR;

namespace Application.Features.Questions.Command.Update;
public class UpdateQuestionCommand : IRequest<UpdateQuestinDto>
{
    public int Id { get; set; }
    public string QuestionDetail { get; set; } = default!;
    public int VacancyId { get; set; }
    public int OptionCount { get; set; }
}

public class UpdateQuestionCommandHandler(IQuestionService questionService, IVacancyService vacancyService, IMapper mapper) : IRequestHandler<UpdateQuestionCommand, UpdateQuestinDto>
{
    public async Task<UpdateQuestinDto> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await questionService.GetAsync(request.Id, cancellationToken);

        await vacancyService.GetAsync(request.VacancyId); 

        question = mapper.Map(request, question);

        question = await questionService.UpdateAsync(question, cancellationToken);

        return mapper.Map<UpdateQuestinDto>(question);
    }
}
