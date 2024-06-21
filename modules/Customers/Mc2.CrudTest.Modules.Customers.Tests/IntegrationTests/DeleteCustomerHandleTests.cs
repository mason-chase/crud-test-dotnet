using FluentAssertions;
using Mc2.CrudTest.Modules.Customers.Application;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.CreateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.DeleteCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.UpdateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Exceptions;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Modules.Customers.Infrastructure;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;
using Mc2.CrudTest.Shared.DataStore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Modules.Customers.Tests.IntegrationTests;

public class DeleteCustomerHandleTests
{
    private readonly ServiceProvider _serviceProvider;
    private readonly IMediator _mediator;
    private readonly AppDbContext _dbContext;
    private readonly IEventStore _eventStore;

    public DeleteCustomerHandleTests()
    {
        _serviceProvider = new ServiceCollection()
            .AddSingleton<IEventStore, EventStore>()
            .AddDbContext<AppDbContext>(c => c.UseInMemoryDatabase(Guid.NewGuid().ToString()))
            .AddCustomersServices()
            .AddMediatR(c =>
            {
                c.Lifetime = ServiceLifetime.Scoped;
                c.RegisterServicesFromAssembly(typeof(IModule).Assembly);
            })
            .BuildServiceProvider();
        _mediator = _serviceProvider.GetRequiredService<IMediator>();
        _dbContext = _serviceProvider.GetRequiredService<AppDbContext>();
        _eventStore = _serviceProvider.GetRequiredService<IEventStore>();
    }

    [Fact]
    public async Task Handle_should_cause_Removing_Customer()
    {
        // Arrange
        var firstName = Name.Create("Arash");
        var lastName = Name.Create("Shabbeh");
        var dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
        var phoneNumber = Phone.Create("+905317251106");
        var email = Email.Create("arash@shabbeh.com");
        var bankAccountNumber = BankAccountNumber.Create("1234567890");
        var createCommand = new CreateCustomerCommand(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
        var customerId = await _mediator.Send(createCommand);

        // Act
        var deleteCommand = new DeleteCustomerCommand(customerId);
        await _mediator.Send(deleteCommand);

        // Value
        var customer = await _dbContext.Customers.FindAsync(customerId.Value);
        customer.Should().BeNull();

        // Events
        var events = _eventStore.GetEvents(customerId.Value);
        events.Should().HaveCount(2);
        events.First().Should().BeOfType<CustomerCreatedEvent>();
        events.Last().Should().BeOfType<CustomerDeletedEvent>();
    }

    [Fact]
    public async Task Handle_should_throw_CustomerNotFoundException_when_Customer_not_found()
    {
        // Arrange
        var customerId = new CustomerId(1);

        // Act
        Func<Task> act = async () => await _mediator.Send(new DeleteCustomerCommand(customerId));

        // Assert
        await act.Should().ThrowAsync<CustomerNotFoundException>();
    }
}