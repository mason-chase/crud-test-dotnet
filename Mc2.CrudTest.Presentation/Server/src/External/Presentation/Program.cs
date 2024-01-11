using Application.Customers.Queries.GetCustomerById;
using Infrastructure;
using Infrastructure.Repositories;
using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Commands.DeleteCustomer;
using Application.Customers.Commands.UpdateCustomer;
using Application.Customers.Queries.GetAllCustomer;
using Application.MappingProfiles;
using Application.Services;
using Application.Services.IContracts;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using MediatR;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRequestHandler<GetCustomerByIdQuery, CustomerResponse>, GetCustomerQueryHandler>();
builder.Services.AddScoped<IRequestHandler<CreateCustomerCommand, int>, CreateCustomerCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, UpdateCustomerCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteCustomerCommand, bool>, DeleteCustomerCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllCustomersQuery,List<CustomerResponse>>, GetAllCustomersQueryHandler>();
builder.Services.AddScoped<INotificationHandler<CustomerCreatedEvent>, CustomerCreatedEventHandler>();
builder.Services.AddScoped<ILoggerService, LoggerService>();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(CustomerMappings));
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();