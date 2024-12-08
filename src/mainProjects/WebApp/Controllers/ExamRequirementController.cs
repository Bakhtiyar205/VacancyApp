using Application.Features.ExamRequirements.Command.Create;
using Application.Features.ExamRequirements.Command.Delete;
using Application.Features.ExamRequirements.Command.Update;
using Application.Features.ExamRequirements.Query.GetById;
using Application.Features.ExamRequirements.Query.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
public class ExamRequirementController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PageRequest request, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(new GetExamRequirementListQuery(request.PageNumber, request.PageSize), cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await Mediator!.Send(new GetExamRequirementByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateExamRequirementCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(command, cancellationToken));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateExamRequirementCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return Ok(await Mediator!.Send(command, cancellationToken));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator!.Send(new DeleteExamRequirementCommand(id));
        return NoContent();
    }
}
