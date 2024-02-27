namespace Mc2.CrudTest.SharedKernel.Domain.Abstraction;

public class ServiceQueryResult<T>
{
    public bool HasError { get { return ErrorMessages?.Any() ?? false; } }
    public bool HasResult { get { return Result != null; } }

    public ServiceQueryResult(T? result)
    {
        Result = result;
    }

    public ServiceQueryResult(IList<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }

    public T? Result { get; private set; } = default(T?);
    public IList<string> ErrorMessages { get; private set; }


}
