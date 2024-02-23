
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mc2.CrudTest.Presentation.Application.Customers;
using Mc2.CrudTest.Presentation.Contracts.Customers;
using Mc2.CrudTest.Presentation.Domain.Customers;
using Mc2.CrudTest.Presentation.EntityFrameworkCore.EntityFrameworkCore;
using Mc2.CrudTest.Presentation.EntityFrameworkCore.EntityFrameworkCore.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Mc2.CrudTest.Presentation.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddControllers();
            services.AddDbContextFactory<CustomerManagementDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext")));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IValidator<CustomerCommand>, CustomerValidator>();

        }
    }

}
