using Hamideh.Crud.Test.Application.CustomerFeatures.Queries.GetCustomerList;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hamideh.Crud.Test.Application;
public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {

        var application = typeof(IAssemblyMarker);

        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssembly(application.Assembly);
            configure.RegisterServicesFromAssemblyContaining<GetCustomerListQueryHandler>();
        });


        return services;
    }
}