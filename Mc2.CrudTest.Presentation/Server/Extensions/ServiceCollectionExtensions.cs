using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.AddDbContext<CrudDbContext>(options =>
            {
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(CrudDbContext).Assembly.FullName));

                var dbContext = new CrudDbContext(options.Options);
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }
            });
        }
    }
}
