using System.Reflection;
using Mc2.CrudTest.Application.UseCases.Customer.Comands.Customer;
using Mc2.CrudTest.Domain.IRepos;
using Mc2.CrudTest.Domain.IRepos.Customer;
using Mc2.CrudTest.Infra.Data;
using Mc2.CrudTest.Infra.Data.Repos;
using Mc2.CrudTest.Infra.Data.Repos.Customer;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

#region Inject Services To Container

builder.Services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CnnStr")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCustomerCommand).GetTypeInfo().Assembly));

#endregion

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
