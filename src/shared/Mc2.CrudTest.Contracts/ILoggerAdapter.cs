namespace Mc2.CrudTest.Contracts;

public interface ILoggerAdapter<T>
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
    void LogError(string message, params object[] args);
    void LogDebug(string message, params object[] args);
}