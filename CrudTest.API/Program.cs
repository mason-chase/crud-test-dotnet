using CrudTest.Data.ExtensionMethods;
using CrudTest.Services.ExtensionMethods;


namespace CrudTest.API
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            const string DEFAULT_CONNECTION_STRING_ALIAS = "DefaultConnection";

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.ApplyInfrastructureConfig(builder.Configuration.GetConnectionString(DEFAULT_CONNECTION_STRING_ALIAS)!);

            builder.Services.ApplyApplicationConfig();


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