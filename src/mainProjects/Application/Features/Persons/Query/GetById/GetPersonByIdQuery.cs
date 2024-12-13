using Application.Features.Persons.Dto;
using Application.Services.PersonQuestionServices;
using Application.Services.PersonServices;
using Application.Services.QuestionServices;
using AutoMapper;
using MediatR;

namespace Application.Features.Persons.Query.GetById;
public class GetPersonByIdQuery(int id) : IRequest<GetPersonDto>
{
    public int Id { get; set; } = id;
}

public class GetPersonByIdQueryHandler(IPersonService personService, IPersonQuestionService personQuestionService, IQuestionService questionService, IMapper mapper) : IRequestHandler<GetPersonByIdQuery, GetPersonDto>
{
    public async Task<GetPersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var person = await personService.GetPersonWithVacancyAsync(request.Id, cancellationToken);

        var correctAnswers = 0;
        var totalAnswers = 0;

        if (person.IsParticipated)
        {
            var personQuestions = await personQuestionService.GetPersonIdAsync(request.Id, cancellationToken);
            var personQuestionAnswers = personQuestions.Where(m => m.AnswerId != 0).Select(m => new
            {
                m.QuestionId,
                m.AnswerId
            }).ToList();

            var questions = await questionService.GetQuestionsAsync(personQuestionAnswers.Select(m => m.QuestionId), cancellationToken);

            var questionsAnswers = questions.Select(m => new
            {
                m.Id,
                AnswerId = m.QuestionOptions.FirstOrDefault(x => x.QuestionId == m.Id && x.IsAnswer)?.Id
            }).ToList();

            correctAnswers = questionsAnswers.Where(m => personQuestionAnswers.Any(x => x.QuestionId == m.Id && x.AnswerId == m.AnswerId)).Count();
            totalAnswers = personQuestionAnswers.Count();
        }
        

        var personDto = mapper.Map<GetPersonDto>(person);
        personDto.CorrectAnswers = correctAnswers;
        personDto.TotalAnswers = totalAnswers;
        return personDto;
    }
}
