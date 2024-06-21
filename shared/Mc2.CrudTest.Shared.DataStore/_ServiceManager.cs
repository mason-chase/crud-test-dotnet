using Mc2.CrudTest.Shared.BuildingBlocks.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Shared.DataStore;

public static class _ServiceManager
{
    public static IServiceCollection AddDataStores(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>((_, optionsBuilder) =>
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString, options =>
            {
                options
                    .MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name)
                    .CommandTimeout(30)
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                    .EnableRetryOnFailure();
            });

            optionsBuilder.EnableDetailedErrors().EnableSensitiveDataLogging();
        });

        services.AddSingleton<IEventStore, EventStore>();
        return services;
    }
}