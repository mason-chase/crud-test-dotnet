using Mc2.CrudTest.Presentation.Server.Core.Repository;
using Mc2.CrudTest.Presentation.Server.Core.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContextFactory<InMemoryDBContext>(
                options =>
                    options.UseInMemoryDatabase(@"StoreDb"));//todo: read from appsetting

			builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

			var app = builder.Build();

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