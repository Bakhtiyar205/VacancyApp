using Core.CrossCuttingConcerns.Exceptions;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.Application.Pipelines.ExceptionLogging;
public class ExceptionLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly FileLogger _fileLogger;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public ExceptionLoggingBehavior(FileLogger fileLogger, IHttpContextAccessor httpContextAccessor)
    {
        _fileLogger = fileLogger;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        string exceptionResponse = string.Empty;
        TResponse? response = default;
        try
        {
            response = await next();
            return response;
        }
        catch (Exception ex)
        {
            exceptionResponse = ex.Message;
            string exceptionData = ExceptionSerializer(next, ex);
            _fileLogger.Error(exceptionData);
            throw;
        }
    }

    private string ExceptionSerializer(RequestHandlerDelegate<TResponse> next, Exception ex)
    {
        LogDetailWithException logDetailWithException = new()
        {
            MethodName = next.Method.Name,
            User = _httpContextAccessor.HttpContext == null ||
                   _httpContextAccessor.HttpContext.User.Identity == null ||
                   _httpContextAccessor.HttpContext.User.Identity.Name == null
                       ? "?"
                       : _httpContextAccessor.HttpContext.User.Identity.Name,
            ExceptionMessage = ex.Message,
            Parameters = new List<LogParameter>()
                {
                    new LogParameter()
                    {
                        Name = "Token",
                        Value = JsonSerializer.Serialize(_httpContextAccessor.HttpContext?.Request.Headers["Authorization"])
                    }
                }
        };
        var exceptionData = JsonSerializer.Serialize(logDetailWithException);
        return exceptionData;
    }
}
