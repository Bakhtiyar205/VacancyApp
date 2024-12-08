using Application.Features.Vacancies.Command.Create;
using Application.Features.Vacancies.Command.Delete;
using Application.Features.Vacancies.Command.Update;
using Application.Features.Vacancies.Query.GetById;
using Application.Features.Vacancies.Query.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class VacancyController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PageRequest request, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(new GetVacancyListQuery(request.PageNumber, request.PageSize), cancellationToken));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await Mediator!.Send(new GetVacancyByIdQuery(id)));
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateVacancyCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(command, cancellationToken));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateVacancyCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return Ok(await Mediator!.Send(command, cancellationToken));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator!.Send(new DeleteVacancyCommand(id));
        return NoContent();
    }
}
