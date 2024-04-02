namespace Application.Commom.Models;

public class Result<T>
{
    internal Result(bool succeeded, List<string> errors, T? value,string message)
    {
        Succeeded = succeeded;
        Errors = errors;
        Value = value;
        Message = message;
    }
    
    internal Result(bool succeeded, List<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors;
        Value = default(T);
    }

    internal Result(bool succeeded, List<string> errors,T value)
    {
        Succeeded = succeeded;
        Errors = errors;
        Value=value;
    }

    internal Result(bool succeeded,string message)
    {
        Succeeded = succeeded;
        Message = message;
        Value = default(T);
    }

    public bool Succeeded { get; set; }

    public List<string>? Errors { get; set; }

    public string? Message { get; set; }

    public T? Value { get; set; }


    public static Result<T> Success(T? value,string message="Operation is done successfully.")
    {
        return new Result<T>(true, null, value, message);
    }
    
    public static Result<T> Failure(List<string> errors)
    {
        return new Result<T>(false, errors);
    }

    public static Result<T> Failure(List<string> errors, T value)
    {
        return new Result<T>(false, errors, value);
    }

    public static Result<T> Failure(string message)
    {
        return new Result<T>(false, message);
    }

}
