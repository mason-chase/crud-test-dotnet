
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Mc2.CrudTest.Core.Domain.Customers.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.AcceptanceTests.Infra
{
    internal class BddTestsApplicationFactory : WebApplicationFactory<Program>
    {

        public readonly InMemoryCustomerRepository customerRepository = new InMemoryCustomerRepository();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<ICustomerRepository>(x =>
                {
                    return customerRepository;
                });
                
            });

            builder.UseEnvironment("Development");
        }
    }
}
