namespace Application.Common.Exceptions;

public class UnknownException : Exception
{
    public UnknownException()
        : base()
    {
    }

    public UnknownException(string message)
        : base(message)
    {
    }

    public UnknownException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

 
}
