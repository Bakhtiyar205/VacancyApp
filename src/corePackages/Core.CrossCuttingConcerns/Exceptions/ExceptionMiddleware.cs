using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ExceptionMiddleware(RequestDelegate next, FileLogger fileLogger, IConfiguration configuration)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);

            RegisteringFatalErrors(context, exception);

        }
    }

    private void RegisteringFatalErrors(HttpContext context, Exception exception)
    {
        if (!(exception is BaseException ||
           exception is ValidationException ||
           exception is TaskCanceledException))
        {
            var serializedException = string.Concat("[HTTP]", JsonSerializer.Serialize(GetLogParameterDetailException(exception, context)));
            fileLogger.Fatal(serializedException);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        if (exception.GetType() == typeof(ValidationException)) return CreateValidationException(context, exception);
        if (exception.GetType() == typeof(BusinessException)) return CreateBusinessException(context, exception);
        if (exception.GetType() == typeof(NotFoundException)) return CreateNotFoundException(context, exception);
        if (exception.GetType() == typeof(AuthorizationException)) return CreateAuthorizationException(context, exception);
        return CreateInternalException(context, exception);
    }

    private Task CreateNotFoundException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);

        var test = new NotFoundProblemDetails
        {
            Status = StatusCodes.Status404NotFound,
            Type = "https://example.com/probs/authorization",
            Title = "Not Found exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString();

        return context.Response.WriteAsync(test);
    }

    private Task CreateAuthorizationException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);

        return context.Response.WriteAsync(new AuthorizationProblemDetails
        {
            Status = StatusCodes.Status401Unauthorized,
            Type = "https://example.com/probs/authorization",
            Title = "Authorization exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }

    private Task CreateBusinessException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

        var message = new BusinessProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://example.com/probs/business",
            Title = "Business exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString();

        return context.Response.WriteAsync(message);
    }

    private Task CreateValidationException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
        object errors = ((ValidationException)exception).Errors;

        return context.Response.WriteAsync(new ValidationProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://example.com/probs/validation",
            Title = "Validation error(s)",
            Detail = "",
            Instance = "",
            Errors = errors
        }.ToString());
    }

    private Task CreateInternalException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

        return context.Response.WriteAsync(JsonSerializer.Serialize(new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://example.com/probs/internal",
            Title = "Internal exception",
            Detail = exception.Message,
            Instance = ""
        }));
    }

    private LogDetailWithException GetLogParameterDetailException(Exception exception, HttpContext context)
    {
        var innerExceptionList = GetInnerExceptionDetail(exception);
        List<LogParameter> logParameters =
        [
             new LogParameter
            {
                Name = "Request Method",
                Value = context.Request.Method
            },
            new LogParameter
            {
                Name = "Request Path",
                Value = context.Request.Path
            },
            new LogParameter
            {
                Name = "Query Parameters",
                Value = JsonSerializer.Serialize(context.Request.Query)
            },
            new LogParameter
            {
                Name = "Stack Trace",
                Value = JsonSerializer.Serialize(exception.StackTrace)
            },
             .. innerExceptionList,

        ];

        LogDetailWithException logDetailWithException = new LogDetailWithException
        {
            FullName = exception.GetType().FullName,
            MethodName = context.Request.Method,
            User = context.User.Identity is not null ? context.User.Identity.Name : "Undefined",
            Parameters = logParameters,
            ExceptionMessage = exception.Message
        };

        return logDetailWithException;
    }

    private static List<LogParameter> GetInnerExceptionDetail(Exception exception)
    {
        List<LogParameter> logParameters = new();
        while(exception.InnerException is not null)
        {
            var logParameter = new LogParameter()
            {
                Name = "Inner Exception",
                Value = exception.InnerException.Message
            };
            logParameters.Add(logParameter);
            exception = exception.InnerException;
        }
        return logParameters;
    }
}