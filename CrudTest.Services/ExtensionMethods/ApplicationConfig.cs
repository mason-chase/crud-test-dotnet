using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrudTest.Services.ExtensionMethods
{
    public static class ApplicationConfig
    {
        public static IServiceCollection ApplyApplicationConfig(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


            return services;
        }
    }
}
