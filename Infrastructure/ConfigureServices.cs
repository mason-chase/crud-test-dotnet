using Application.Interfaces.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<CrudDbContext>(options =>
                {
                    options.UseInMemoryDatabase("CrudTest");
                    
                });
            }
            else
            {

                services.AddDbContext<CrudDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(CrudDbContext).Assembly.FullName));

                    var dbContext = new CrudDbContext(options.Options);
                    if (dbContext.Database.GetPendingMigrations().Any())
                    {
                        dbContext.Database.Migrate();
                    }
                });
            }
            return services;
        }
    }
}
