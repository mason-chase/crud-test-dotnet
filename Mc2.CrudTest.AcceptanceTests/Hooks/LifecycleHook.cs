using AutoMapper;
using FluentValidation;
using Mc2.CrudTest.AcceptanceTests.Drivers;
using Mc2.CrudTest.Presentation.Application.Customers;
using Mc2.CrudTest.Presentation.Contracts.Customers;
using Mc2.CrudTest.Presentation.Domain.Customers;
using Mc2.CrudTest.Presentation.EntityFrameworkCore.EntityFrameworkCore;
using Mc2.CrudTest.Presentation.EntityFrameworkCore.EntityFrameworkCore.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SolidToken.SpecFlow.DependencyInjection;


namespace Mc2.CrudTest.AcceptanceTests.Hooks
{
    [Binding]
    public class LifecycleHook
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IValidator<CustomerCommand>, CustomerValidator>();
            services.AddScoped<ICustomerDriver, CustomerDriver>();
            services.AddScoped<TestContext>();
            services.AddDbContextFactory<CustomerManagementDbContext>(options =>
            options.UseSqlServer("Data Source=.;Initial Catalog=CustomerManagement;Integrated Security=true;TrustServerCertificate=True"));
            return services;
        }
    }
}

