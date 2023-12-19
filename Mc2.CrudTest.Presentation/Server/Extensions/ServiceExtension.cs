using System.Reflection;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Handlers.CommandHandlers;
using Mc2.CrudTest.Application.Handlers.QueryHandlers;
using Mc2.CrudTest.Infrastructure.Data;
using Mc2.CrudTest.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Mc2.CrudTest.Presentation.Server.Extensions;

public static class ServiceExtension
{
    public static void Inject(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSerilog();
        var connectionString = configuration.GetConnectionString("sqlConnection");
        services.AddDbContext<EfDbContext>(options => { options.UseSqlServer(connectionString); });

        services.AddTransient<ICustomersRepository, CustomersRepository>();
         services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(Program).Assembly));
       
    }
}