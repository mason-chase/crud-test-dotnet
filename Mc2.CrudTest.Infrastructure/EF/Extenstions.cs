using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Infrastructure.EF.Contexts;
using Mc2.CrudTest.Infrastructure.EF.Repositories;
using Mc2.CrudTest.Infrastructure.EF.Services;
using Mc2.CrudTest.Infrastructure.EF.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mc2.CrudTest.Shared.Options;

namespace Mc2.CrudTest.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerReadService, CustomerReadService>();          

            var options = configuration.GetOptions<DataBaseOptions>("DataBaseConnectionString");
            services.AddDbContext<ReadDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString,x=>x.UseDateOnlyTimeOnly()));

            services.AddDbContext<WriteDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString, x => x.UseDateOnlyTimeOnly()));

            return services;
        }
    }
}
