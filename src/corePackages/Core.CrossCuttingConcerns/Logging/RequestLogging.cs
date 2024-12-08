using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Text;


namespace Core.CrossCuttingConcerns.Logging;
public class RequestLoggingMiddleware(RequestDelegate next, FileLogger fileLogger, IConfiguration configuration)
{
    private readonly Dictionary<string, string> _apiListWithoutBody = configuration.GetSection("LogWithoutBody").Get<Dictionary<string, string>>()!;

    public async Task Invoke(HttpContext httpContext)
    {
        bool isSwaggerRelatedRequest = httpContext.Request.Path.ToString().StartsWith("/swagger/");

        var threadId = Environment.CurrentManagedThreadId;
        var canLog = !isSwaggerRelatedRequest;
        if (canLog)
        {
            StringBuilder loggingData = new StringBuilder();
            string? clientIp = httpContext.Connection.RemoteIpAddress?.ToString();
            string? clientPort = httpContext.Connection.RemotePort.ToString();

            HttpRequest request = httpContext.Request;

            HttpRequestRewindExtensions.EnableBuffering(request);


            if (!_apiListWithoutBody.Values.Any(value => string.Equals(value, request.Path.Value, StringComparison.OrdinalIgnoreCase)))
            {
                using (StreamReader reader = new(request.Body, Encoding.UTF8, true, 1024, true))
                { 
                    loggingData.Append(await reader.ReadToEndAsync()); 
                }
            }
            

            if (!string.IsNullOrEmpty(httpContext.Request.QueryString.Value)) loggingData.Append(httpContext.Request.QueryString.Value);

            request.Body.Position = 0;

            fileLogger.Info(LoggingText(httpContext, loggingData, clientIp, clientPort, request));
        }

        await next(httpContext);
    }

    private string LoggingText(HttpContext httpContext, StringBuilder loggingData, string? clientIp, string clientPort, HttpRequest request)
    {
       return string.Format(RequestLoggingMessage.TextLog,clientIp, clientPort, request.Path, request.Method, loggingData, httpContext.Request.Headers["Authorization"]);
    }
}
