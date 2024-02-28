
using Mc2.CrudTest.Application.Handlers.Customers.Commands;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.SharedKernel.Domain.Abstraction;
using MediatR;


namespace Mc2.CrudTest.Presentation
{
    public static class Handlers
    {
        public static IServiceCollection RegisterHandlers(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CustomerAddCommand, ServiceCommandResult>, CustomerAddCommandHandler>();

            return services;
        }
    }
}
