using Application.Features.Questions.Dto;
using Application.Services.QuestionServices;
using Application.Services.VacancyServices;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Questions.Command.Create;
public class CreateQuestionCommand : IRequest<CreateQuestionDto>
{
    public string QuestionDetail { get; set; } = default!;
    public int VacancyId { get; set; }
    public int OptionCount { get; set; }
}

public class CreateQuestionCommandHandler(IQuestionService questionService, IVacancyService vacancyService, IMapper mapper) : IRequestHandler<CreateQuestionCommand, CreateQuestionDto>
{
    public async Task<CreateQuestionDto> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = mapper.Map<Question>(request);

        await vacancyService.GetAsync(request.VacancyId);

        question = await questionService.CreateAsync(question);

        return mapper.Map<CreateQuestionDto>(question);
    }
}
