
using Mc2.CrudTest.Application.Interfaces.Context;
using Mc2.CrudTest.Application.Services.Customers.Command.EditCustomer;
using Mc2.CrudTest.Application.Services.Customers.Command.RegisterCustomer;
using Mc2.CrudTest.Application.Services.Customers.Command.RemoveCustomer;
using Mc2.CrudTest.Application.Services.Customers.Query.GetCustomerByID;
using Mc2.CrudTest.Application.Services.Customers.Query.GetCustomers;
using Mc2.CrudTest.Presistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mc2.CrudTest.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
            builder.Services.AddScoped<IGetCustomersService, GetCustomersService>();
            builder.Services.AddScoped<IRegisterCustomerService, RegisterCustomerService>();
            builder.Services.AddScoped<IEditCustomerService, EditCustomerService>();
            builder.Services.AddScoped<IGetCustomerByID, GetCustomerByID>();
            builder.Services.AddScoped<IRemoveCustomer, RemoveCustomer>();

            string connectionString = builder.Configuration.GetConnectionString("ConnStr");
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(connectionString));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
    }
}