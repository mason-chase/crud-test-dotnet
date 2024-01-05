
using EventStore.ClientAPI;
using Mc2.CrudTest.Core.ApplicationService.Customers.CommandHandlers;
using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Framework.Domain.Data;
using Mc2.CrudTest.Infrastructure.Data.SqlServer;
using Mc2.CrudTest.Infrastructure.Data.SqlServer.Customers;
using Event = Mc2.CrudTest.Infracture.Data.EventSourcing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<ICustomerQueryRepository, CustomerQueryRespository>();
builder.Services.AddScoped(c => new SqlConnection(builder.Configuration.GetConnectionString("CustomerCnn")));

builder.Services.AddScoped<ICustomerRepository, EfCustomerRespository>();
builder.Services.AddScoped<IUnitOfWork, CustomerUnitOfWork>();
builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerCnn"));
});

builder.Services.AddScoped<CreateCustomerCommandHandler>();  
builder.Services.AddScoped<UpdateCustomerCommandHandler>();
builder.Services.AddScoped<DeleteCustomerCommandHandler>();


var connectionString = "ConnectTo=tcp://admin:changeit@localhost:1113;";
var connection = EventStoreConnection.Create(connectionString, ConnectionSettings.Create().KeepReconnecting(), 
                                              builder.Environment.ApplicationName);


var store = new Event.EventStore(connection);

builder.Services.AddSingleton(connection);  
builder.Services.AddSingleton<IEventSource>(store);  


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
