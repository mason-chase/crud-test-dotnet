using CrudTest.API.Middlewares;
using Microsoft.OpenApi.Models;

using CrudTest.Services.ExtensionMethods;
using CrudTest.Data.ExtensionMethods;


namespace CrudTest.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            const string DEFAULT_CONNECTION_STRING_ALIAS = "DefaultConnection";

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.ApplyInfrastructureConfig(Configuration.GetConnectionString(DEFAULT_CONNECTION_STRING_ALIAS)!);

            services.ApplyApplicationConfig();

            services.AddSingleton<ExceptionHandlerMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseMiddleware<ExceptionHandlerMiddleware>();


            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
