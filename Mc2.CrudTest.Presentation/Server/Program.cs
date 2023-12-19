using Mc2.CrudTest.Application;
using Mc2.CrudTest.Presentation.Server.Extensions;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    
    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.File(Environment.CurrentDirectory)
        .CreateLogger();
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(logger);
    Log.Logger.Information("Application Started...");
    
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
   // builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddCors(p => p.AddPolicy("corsPolicy", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }));
    builder.Services.AddApplicationServices();
     ServiceExtension.Inject(builder.Services, builder.Configuration);

    var app = builder.Build();

  
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.UseCors("corsPolicy");
  //  app.UseHttpsRedirection();
    // app.UseCustomExceptionHandler();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    Log.Logger.Error(e.Message);
}
finally
{
    Log.Logger.Information("shutting down...");
    
}