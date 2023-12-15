using Mc2.CrudTest.Shared.Abstraction.Command;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Shared.Command
{
    internal sealed class InMemoryCommandDispatcher : ICommandDistpatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task Dispatch<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

            await handler.Handle(command);
        }
    }
}
