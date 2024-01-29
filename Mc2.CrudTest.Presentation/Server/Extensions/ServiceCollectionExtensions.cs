using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<CrudContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
