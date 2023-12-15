using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Infrastructure.EF;
using Mc2.CrudTest.Shared.Abstraction.Command;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mc2.CrudTest.Shared.Queries;
using Mc2.CrudTest.Infrastructure.Logging;
using Mc2.CrudTest.Infrastructure.EF.Services;

namespace Mc2.CrudTest.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSQLDB(configuration);
            services.AddQueries();

            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

            return services;
        }
    }
}
