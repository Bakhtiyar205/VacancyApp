using Application.Features.QuestionOptions.Command.Create;
using Application.Features.QuestionOptions.Command.Delete;
using Application.Features.QuestionOptions.Command.DeleteByQuestion;
using Application.Features.QuestionOptions.Command.Update;
using Application.Features.QuestionOptions.Query.GetById;
using Application.Features.QuestionOptions.Query.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class QuestionOptionController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetPaginatedAsync([FromQuery] PageRequest pageRequest, [FromQuery] int questionId, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(new GetQuestionOptionListQuery(pageRequest.PageNumber, pageRequest.PageSize, questionId), cancellationToken));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(new GetQuestionOptionByIdQuery(id), cancellationToken));
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateQuestionOptionCommand request, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(request, cancellationToken));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateQuestionOptionCommand request, CancellationToken cancellationToken)
    {
        request.Id = id;
        return Ok(await Mediator!.Send(request, cancellationToken));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        await Mediator!.Send(new DeleteQuestionOptionCommand(id), cancellationToken);
        return NoContent();
    }
    [HttpDelete("Question/{id}")]
    public async Task<IActionResult> DeleteByQuestionAsync([FromRoute] int id, CancellationToken cancellationToken, [FromQuery] int size = 100)
    {
        await Mediator!.Send(new DeleteByQuestionCommand(id, size), cancellationToken);
        return NoContent();
    }
}
