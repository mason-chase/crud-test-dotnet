using Mc2.CrudTest.Contracts;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Mc2.CrudTest.Infra.Logging;

public class SerilogAdapter<T> : ILoggerAdapter<T>
{
    private readonly Logger _logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .WriteTo.File(
            $"logs/log-{DateTime.Now}.log",
            rollingInterval: RollingInterval.Day,
            restrictedToMinimumLevel: LogEventLevel.Information,
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
        .WriteTo.Console()
        .CreateLogger();

    public void LogInformation(string message, params object[] args)
    {
        _logger.Information(message, args);
    }

    public void LogWarning(string message, params object[] args)
    {
        _logger.Warning(message, args);
    }

    public void LogError(string message, params object[] args)
    {
        _logger.Error(message, args);
    }

    public void LogDebug(string message, params object[] args)
    {
        _logger.Debug(message, args);
    }
}
