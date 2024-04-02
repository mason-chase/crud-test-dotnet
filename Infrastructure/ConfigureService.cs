using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence;
using Application.Common.Interfaces.Tools;


namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        services.AddDbContext<CrudTestDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CrudTestConnection"),
                builder => builder.MigrationsAssembly(typeof(CrudTestDbContext).Assembly.FullName)));


        services.AddScoped<ICrudTestDbContext>(provider => provider.GetRequiredService<CrudTestDbContext>());
        services.AddScoped<CrudTestDbContextInitialiser>();

 
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}