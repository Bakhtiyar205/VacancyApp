using Application.Features.PersonQuestions.Query.GetByVacancyPeronId;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class PersonQuestionController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetQuestionList([FromQuery] int personId, [FromQuery] int vacancyId, CancellationToken cancellationToken)
    {
        var personQuestions = await Mediator!.Send(new GetByVacancyPersonIdQuery(personId, vacancyId), cancellationToken);
        return Ok(personQuestions);
    }
}
