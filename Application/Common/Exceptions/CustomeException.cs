namespace Application.Common.Exceptions;

public class CustomeException : Exception
{
    public CustomeException()
        : base()
    {
    }

    public CustomeException(string message)
        : base(message)
    {
    }

    public CustomeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CustomeException(List<string> message)
        : base(message.FirstOrDefault())
    {
    }
}
