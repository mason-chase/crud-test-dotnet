using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Policies;
using Microsoft.Extensions.DependencyInjection;
using Mc2.CrudTest.Shared.Command;

namespace Mc2.CrudTest.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<ICustomerFactory, CustomerFactory>();

            services.Scan(b => b.FromAssemblies(typeof(ICustomerRegisterPolicy).Assembly)
                .AddClasses(c => c.AssignableTo<ICustomerRegisterPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }
    }
}
