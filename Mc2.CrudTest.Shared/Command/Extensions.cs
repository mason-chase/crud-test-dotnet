using Mc2.CrudTest.Shared.Abstraction.Command;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Mc2.CrudTest.Shared.Command
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDistpatcher, InMemoryCommandDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
            return services;
        }
    }
}
