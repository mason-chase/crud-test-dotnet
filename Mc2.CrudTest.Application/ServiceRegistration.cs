using Mc2.CrudTest.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Application;

public static class ServiceRegistration
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceRegistration));
    }
}