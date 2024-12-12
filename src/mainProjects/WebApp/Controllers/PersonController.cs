using Application.Features.Persons.Command.AddCv;
using Application.Features.Persons.Command.AgreeExam;
using Application.Features.Persons.Command.Create;
using Application.Features.Persons.Query.GetById;
using Application.Features.Persons.Query.GetCv;
using Application.Features.Persons.Query.GetList;
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

    [HttpPut("{id}")]
    public async Task<IActionResult> AgreeExam([FromRoute] int id, [FromBody] AgreeExamCommand agreeExamCommand, CancellationToken cancellationToken)
    {
        agreeExamCommand.PersonId = id;
        return Ok(await Mediator!.Send(agreeExamCommand, cancellationToken));
    }

    [HttpPut("cv/{id}")]
    public async Task<IActionResult> AddCv([FromRoute] int id, [FromForm] IFormFile file, CancellationToken cancellationToken)
    {
        return Ok(await Mediator!.Send(new AddCvCommand(id, file), cancellationToken));
    }

    [HttpGet("cv/{id}")]
    public async Task<IActionResult> GetCv([FromRoute] int id, CancellationToken cancellationToken)
    {
        var path = await Mediator!.Send(new GetCvData(id), cancellationToken);


        return File(path.FileByte, path.FileType, Path.GetFileName(path.FilePath));
    }
}
