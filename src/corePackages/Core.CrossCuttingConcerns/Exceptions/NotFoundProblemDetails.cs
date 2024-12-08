using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions;
public class NotFoundProblemDetails : ProblemDetails
{
    public override string ToString() => JsonSerializer.Serialize(this);
}
