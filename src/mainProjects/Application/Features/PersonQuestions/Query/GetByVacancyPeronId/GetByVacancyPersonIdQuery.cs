using Application.Features.PersonQuestions.Dto;
using Application.Services.PersonQuestionServices;
using AutoMapper;
using MediatR;

namespace Application.Features.PersonQuestions.Query.GetByVacancyPeronId;
public class GetByVacancyPersonIdQuery(int vacancyId, int personId) : IRequest<IList<PersonQuestionDto>>
{
    public int VacancyId { get; set; } = vacancyId;
    public int PersonId { get; set; } = personId;
}

public class GetByVacancyPersonIdQueryHandler(IPersonQuestionService personQuestionService, IMapper mapper) : IRequestHandler<GetByVacancyPersonIdQuery, IList<PersonQuestionDto>>
{
    public async Task<IList<PersonQuestionDto>> Handle(GetByVacancyPersonIdQuery request, CancellationToken cancellationToken)
    {
        var personQuestion = await personQuestionService.GetListByPersonVacancyIdAsync(request.VacancyId, request.PersonId, cancellationToken);

        return mapper.Map<List<PersonQuestionDto>>(personQuestion);

    }
}
