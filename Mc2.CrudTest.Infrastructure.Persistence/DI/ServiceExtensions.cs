using Mc2.CrudTest.Domain.Contract;
using Mc2.CrudTest.Domain.Contract.Customers;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure.Persistence.DI;

public static class ServiceExtensions
{
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<WriteDbContext>(o =>
        {
            o.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            o.UseSqlServer(config.GetConnectionString("SqlConnection"));
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<EventStoreDbContext>(o =>
        {
            o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            o.UseSqlServer(config.GetConnectionString("SqlConnection"));
        });
        services.AddScoped<IEventStoreRepository, EventStoreRepository>();
        services.AddScoped<ICustomerWriteOnlyRepository, CustomerWriteOnlyRepository>();
    }
}
