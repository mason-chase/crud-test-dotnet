using Autofac;
using Mc2.Framework.Application;

namespace Mc2.Framework.Infrastructure.Config;

public class CommandBus(ILifetimeScope lifetimeScope) : ICommandBus
{
    public Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
    {
        ICommandHandler<TCommand> handler = lifetimeScope.Resolve<ICommandHandler<TCommand>>();
        return handler.Handle(command);
    }
}