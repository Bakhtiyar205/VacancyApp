using Application.Features.Persons.Command.Create;
using Application.Features.Persons.Query.GetById;
using Application.Features.Persons.Query.GetList;
using Application.Features.Questions.Command.Create;
using Application.Features.Questions.Command.Delete;
using Application.Features.Questions.Command.DeleteByVacancy;
using Application.Features.Questions.Command.Update;
using Application.Features.Questions.Query.GetById;
using Application.Features.Questions.Query.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class PersonController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetPaginatedAsync([FromQuery] PageRequest pageRequest, [FromQuery] int vacancyId, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(new GetPersonListQuery(pageRequest.PageNumber, pageRequest.PageSize, vacancyId), cancellationToken));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(new GetPersonByIdQuery(id), cancellationToken));
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePersonCommand request, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(request, cancellationToken));
    }
}
