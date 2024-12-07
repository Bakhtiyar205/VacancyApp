namespace Core.CrossCuttingConcerns.Exceptions;
public class NotFoundException : BaseException
{
    public NotFoundException(string message) : base(message)
    {
    }
}
