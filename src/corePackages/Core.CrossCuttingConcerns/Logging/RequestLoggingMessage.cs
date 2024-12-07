namespace Core.CrossCuttingConcerns.Logging;
public static class RequestLoggingMessage
{
    public const string TextLog = "[HTTPRequest]client ip: {0}; client port: {1}; requestedUrl: {2}; requestMethod: {3}; requestData: {4}; token: {5}";
}
