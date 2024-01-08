namespace Mc2.Framework.Application;

public interface ICommandBus
{
    Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand;
}