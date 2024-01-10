using FluentValidation;
using Mc2.CrudTest.Application.Contract.Customers.Mappers;
using Mc2.CrudTest.Application.Customers.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mc2.CrudTest.Application.DI;

public static class ServiceExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services
            .AddValidatorsFromAssembly(assembly, ServiceLifetime.Scoped, null, true)
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddScoped<ICreateCustomerCommandMapper, CreateCustomerCommandMapper>();
    }
}
