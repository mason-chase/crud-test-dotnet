using Mc2.CrudTest.Domain.Contract.Customers;
using Mc2.CrudTest.Infrastructure.Query.DbContexts;
using Mc2.CrudTest.Infrastructure.Query.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure.Query.DI;

public static class ServiceExtensions
{
    public static void AddQueryLayer(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ReadDbContext>(o =>
        {
            o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            o.UseSqlServer(config.GetConnectionString("SqlConnection"));
        });
        services.AddScoped<ICustomerReadOnlyRepository, CustomerReadOnlyRepository>();
    }
}
