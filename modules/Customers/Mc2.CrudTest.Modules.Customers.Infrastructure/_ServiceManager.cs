using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.GetCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Modules.Customers.Infrastructure;

public static class _ServiceManager
{
    public static IServiceCollection AddCustomersServices(this IServiceCollection services)
    {
        services.AddTransient<IReadModelRepository<CustomerDto>, CustomerReadModelRepository>();
        services.AddScoped<IRepository<Customer, CustomerId>, CustomersRepository>();
        return services;
    }
}