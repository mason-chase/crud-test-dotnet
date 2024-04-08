using Application;
using Microsoft.AspNetCore.HttpLogging;
using NLog.Web;
using Persistence;

NLog.Logger _nlog = NLog.LogManager.GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseNLog();

    AddServices(builder);

    var app = builder.Build();

    AddConfigurations(app, builder);

    app.Run();
}
catch (Exception e)
{
    _nlog.Error(e, e.Message);
}

#region ServiceMethods

void AddServices(WebApplicationBuilder builder)
{
    GeneralServices(builder);
    LayersServices(builder);
}

void GeneralServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(options =>
    {
        options.CustomSchemaIds(type => type.ToString());
    });

    builder.Services.AddHttpLogging(logging =>
    {
        logging.LoggingFields = HttpLoggingFields.All;
    });
}

void LayersServices(WebApplicationBuilder builder)
{
    builder.Services.AddApplicationLayer();
    builder.Services.AddPersistenceInfrastructure(builder.Configuration);
}

#endregion ServiceMethods

#region ConfigureMethods

void AddConfigurations(WebApplication app, WebApplicationBuilder builder)
{
    GeneralConfiguration(app, builder);
    ConfigureEndPoints(app);
}
void GeneralConfiguration(WebApplication app, WebApplicationBuilder builder)
{
    app.Use(async (context, next) =>
    {
        context.Request.EnableBuffering();
        await next();
    });

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        });
    }

    app.UseStaticFiles();

    app.UseRouting();
}

void ConfigureEndPoints(WebApplication app)
{
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}

#endregion ConfigureMethods