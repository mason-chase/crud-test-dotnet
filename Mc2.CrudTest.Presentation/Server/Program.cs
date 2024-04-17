using Mc2.CrudTest.Presentation.Infrastructure.Cache;
using Mc2.CrudTest.Presentation.Infrastructure.Data;
using Mc2.CrudTest.Presentation.Infrastructure.ServiceRegistrar;
using Microsoft.AspNetCore.ResponseCompression;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCacheProvider(builder.Configuration);

            builder.Services.AddDbContextConfig(builder.Configuration);

            builder.Services.AddServices();

            builder.Services.AddApplicationServices();

            //builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies([typeof(Program).Assembly, typeof(Presentation.Application.Customers.Queries.GetCustomers.GetCustomersQueryHandler).Assembly]);



            builder.Services.AddSwaggerGen();

            // Add services to the container.



            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }

            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}