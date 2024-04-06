using Application;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings_DefaultConnection");

builder.Services.AddDbContext<CustomerDbContext>(options =>
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        .UseSqlServer(connectionString ?? builder.Configuration.GetConnectionString("DefaultConnection"))
    );
ApplicationLogic.RegisterApplicationServices(builder.Services);
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
