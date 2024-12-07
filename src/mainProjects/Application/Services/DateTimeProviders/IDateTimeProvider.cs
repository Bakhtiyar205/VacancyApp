using Domain.Constants;

namespace Application.Services.DateTimeProviders;
public interface IDateTimeProvider
{
    private static TimeZoneInfo AzerbaijanTimeZoneInfo
        => TimeZoneInfo.FindSystemTimeZoneById(DateTimeConstants.AzerbaijanTimeZoneId);

    public static DateTime Now => TimeZoneInfo.ConvertTime(DateTime.UtcNow, AzerbaijanTimeZoneInfo);

    public static DateTime DateNow => Now.Date;
}
