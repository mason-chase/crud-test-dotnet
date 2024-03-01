using Mc2.CrudTest.Presentation.Infrastructure.Data;
using Mc2.CrudTest.Presentation.Shared.Interfaces.Data;
using Microsoft.Extensions.DependencyInjection;


namespace Mc2.CrudTest.Presentation.Infrastructure.ServiceRegistrar
{
    public static class ServiceRegistrarStartup
    {
        public static void AddServices(this IServiceCollection services)
        {

            // services
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<IQueryRepository, QueryRepository>();


        }
    }
}
