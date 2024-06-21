using System.Reflection;
using Mc2.CrudTest.Modules.Customers.Application;
using Mc2.CrudTest.Modules.Customers.Infrastructure;
using Mc2.CrudTest.Presentation.Server.ExceptionHandlers;
using Mc2.CrudTest.Shared.DataStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CRUD",
                    Version = "v1",
                    Description = "CRUD API",
                    Contact = new OpenApiContact
                    {
                        Name = "iamr8",
                        Email = "arash.shabbeh@gmail.com"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath, true);
            });
            builder.Services.AddCustomersServices();
            builder.Services.AddDataStores(builder.Configuration);
            builder.Services.AddMediatR(c =>
            {
                c.Lifetime = ServiceLifetime.Scoped;
                c.RegisterServicesFromAssembly(typeof(IModule).Assembly);
            });
            builder.Services.AddSingleton<CustomExceptionHandler>();

            WebApplication app = builder.Build();
            
            using (IServiceScope scope = app.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                AppDbContext context = services.GetRequiredService<AppDbContext>();
                if (context.Database.IsRelational())
                {
                    if ((await context.Database.GetPendingMigrationsAsync()).Any())
                    {
                        await context.Database.MigrateAsync();
                    }
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseExceptionHandler(CustomExceptionHandler.Run);

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            await app.RunAsync();
        }
    }
}