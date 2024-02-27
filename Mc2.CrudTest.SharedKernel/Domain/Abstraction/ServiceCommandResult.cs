namespace Mc2.CrudTest.SharedKernel.Domain.Abstraction;

public class ServiceCommandResult
{
    public string Id { get; private set; }
    public bool WasSuccessfull { get { return ErrorType == null; } }
    public CommandErrorType? ErrorType { get; private set; } = null;
    public IList<string> ErrorMessages { get; private set; }
    public string Uri { get; set; }

    public ServiceCommandResult() { }
    public ServiceCommandResult(CommandErrorType errorType)
    {
        ErrorType = errorType;
    }

    public ServiceCommandResult(CommandErrorType errorType, IList<string> errorMessage) : this(errorType)
    {
        ErrorMessages = errorMessage;
    }

    public ServiceCommandResult(CommandErrorType errorType, string errorMessage) : this(errorType, new string[] { errorMessage })
    {

    }

    public ServiceCommandResult(string id)
    {
        Id = id;
    }

    public static ServiceCommandResult Done() => new ServiceCommandResult();
    public static ServiceCommandResult NotFound() => new ServiceCommandResult(CommandErrorType.NotFound);
    public static ServiceCommandResult Error(string error) => new ServiceCommandResult(CommandErrorType.General, error);
    public static ServiceCommandResult ValidationErorr(string error) => new ServiceCommandResult(CommandErrorType.Validation, error);

}


