namespace Core.Application.Requests;

public class PageRequest
{
    public int PageNumber { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}