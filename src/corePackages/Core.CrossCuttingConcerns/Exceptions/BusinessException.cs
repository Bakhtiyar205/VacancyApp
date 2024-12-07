namespace Core.CrossCuttingConcerns.Exceptions;

public class BusinessException : BaseException
{
    public BusinessException(string message) : base(message)
    {
    }
}