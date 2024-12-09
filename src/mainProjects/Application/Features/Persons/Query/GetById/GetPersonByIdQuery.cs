using Application.Features.Persons.Dto;
using Application.Services.PersonServices;
using AutoMapper;
using MediatR;

namespace Application.Features.Persons.Query.GetById;
public class GetPersonByIdQuery(int id) : IRequest<GetPersonDto>
{
    public int Id { get; set; } = id;
}

public class GetPersonByIdQueryHandler(IPersonService personService, IMapper mapper) : IRequestHandler<GetPersonByIdQuery, GetPersonDto>
{
    public async Task<GetPersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var person = await personService.GetPersonWithVacancyAsync(request.Id, cancellationToken);

        return mapper.Map<GetPersonDto>(person);
    }
}
