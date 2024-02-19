using CrudTest.Services.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrudTest.Services.ExtensionMethods
{
    public static class ApplicationConfig
    {
        public static IServiceCollection ApplyApplicationConfig(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {

                config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



            return services;
        }
    }
}
