using CrudTest.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CrudTest.Data.ExtensionMethods
{
    public static class InfrastructureConfig
    {
        public static IServiceCollection ApplyInfrastructureConfig(this IServiceCollection services,string connectionString,bool isTesting=false)
        {
            if (!isTesting)
            {
                services.AddDbContext<MarketingDbContext>(x => x.UseSqlServer(connectionString, y => y.UseDateOnlyTimeOnly()));
            }

            else
            {
                services.AddDbContext<MarketingDbContext>(x => x.UseInMemoryDatabase(Guid.NewGuid().ToString()),ServiceLifetime.Singleton);
            }
            return services;
        }
    }
}
