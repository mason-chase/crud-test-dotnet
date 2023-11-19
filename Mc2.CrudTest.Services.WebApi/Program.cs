using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString =
	builder.Configuration.GetConnectionString(name: "ConnectionString");

builder.Services.AddDbContext<Persistence.DatabaseContext>
	(optionsAction: options =>
	{
		options
			.UseLazyLoadingProxies();
		options
			.UseSqlServer(connectionString: connectionString);
	});

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{ Title = "Customer Services", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Services V1");
});

app.Run();
