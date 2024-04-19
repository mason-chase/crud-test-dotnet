using Mc2.CrudTest.Application.Handlers.CommandHandlers;
using Mc2.CrudTest.Application.Handlers.QueryHandlers;
using Mc2.CrudTest.Presentation.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreateCustomerCommandHandler).Assembly));
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(UpdateCustomerCommandHandler).Assembly));
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(RemoveCustomerCommandHandler).Assembly));
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(GetCustomerByIdQueryHandler).Assembly));
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(GetCustomerByPhoneQueryHandler).Assembly));
        return services;
    }
}