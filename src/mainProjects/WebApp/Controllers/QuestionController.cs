using Application.Features.Questions.Command.Create;
using Application.Features.Questions.Command.Delete;
using Application.Features.Questions.Command.Update;
using Application.Features.Questions.Query.GetById;
using Application.Features.Questions.Query.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class QuestionController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetPaginatedAsync([FromQuery] PageRequest pageRequest, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(new GetQuestionListQuery(pageRequest.PageNumber, pageRequest.PageSize),cancellationToken));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(new GetQuestionByIdQuery(id),cancellationToken));
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(request, cancellationToken));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute]int id, [FromBody]UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        request.Id = id;
        return Ok(await Mediator!.Send(request, cancellationToken));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute]int id, CancellationToken cancellationToken)
    {
        await Mediator!.Send(new DeleteQuestionCommand(id), cancellationToken);
        return NoContent();
    }
    
}
