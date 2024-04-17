using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


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
