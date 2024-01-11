using Application.Customers.Queries.GetCustomerById;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using Application.Customers.Commands.CreateCustomer;
using Application.MappingProfiles;
using CQRS.NET;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using MediatR; // Import MediatR namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRequestHandler<GetCustomerByIdQuery, CustomerResponse>, GetCustomerQueryHandler>();
builder.Services.AddScoped<IRequestHandler<CreateCustomerCommand, int>, CreateCustomerCommandHandler>();

// Register MediatR
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(CustomerMappings));
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();