using Mc2.CrudTest.Core.ApplicationService.Customers.CommandHandlers;
using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Framework.Domain.Data;
using Mc2.CrudTest.Infrastructure.Data.SqlServer;
using Mc2.CrudTest.Infrastructure.Data.SqlServer.Customers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICustomerRepository, EfCustomerRespository>();
builder.Services.AddScoped<IUnitOfWork, CustomerUnitOfWork>();
builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerCnn"));
});

builder.Services.AddScoped<CreateCustomerCommandHandler>();  
builder.Services.AddScoped<UpdateCustomerCommandHandler>();
builder.Services.AddScoped<DeleteCustomerCommandHandler>();




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
