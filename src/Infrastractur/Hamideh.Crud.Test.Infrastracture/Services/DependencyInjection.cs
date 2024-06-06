using Hamideh.Crud.Test.Domain;
using Hamideh.Crud.Test.Infrastracture.Persistence;
using Hamideh.Crud.Test.Infrastracture.Persistence.SqlContext;
using Hamideh.Crud.Test.Infrastracture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hamideh.Crud.Test.Infrastracture;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<CustomerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(CustomerDbContextSchema.DefaultConnectionStringName));
        });

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}