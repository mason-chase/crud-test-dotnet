using FluentAssertions;
using Mc2.CrudTest.Modules.Customers.Application;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.CreateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Exceptions;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Modules.Customers.Infrastructure;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;
using Mc2.CrudTest.Shared.DataStore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Modules.Customers.Tests.IntegrationTests;

public class CreateCustomerHandleTests
{
    private readonly ServiceProvider _serviceProvider;
    private readonly IMediator _mediator;
    private readonly AppDbContext _dbContext;
    private readonly IEventStore _eventStore;

    public CreateCustomerHandleTests()
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
    public async Task Handle_should_cause_Creating_Customer()
    {
        // Arrange
        var firstName = Name.Create("John");
        var lastName = Name.Create("Doe");
        var dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
        var phoneNumber = Phone.Create("+905317251106");
        var email = Email.Create("arash@shabbeh.com");
        var bankAccountNumber = BankAccountNumber.Create("1234567890");
        var command = new CreateCustomerCommand(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);

        // Act
        var customerId = await _mediator.Send(command);

        // Assert
        customerId.Should().NotBeNull();
        customerId.Value.Should().BeGreaterThan(0);

        // Value
        var customer = await _dbContext.Customers.FindAsync(customerId.Value);
        customer.Should().NotBeNull();
        customer.FirstName.Should().Be(firstName.Value);
        customer.LastName.Should().Be(lastName.Value);
        customer.DateOfBirth.Should().Be(dateOfBirth.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc));
        customer.PhoneNumber.Should().Be(phoneNumber.Value);
        customer.Email.Should().Be(email.Value);
        customer.BankAccountNumber.Should().Be(bankAccountNumber.Value);

        // Events
        var events = _eventStore.GetEvents(customerId.Value);
        events.Should().HaveCount(1);
        events.First().Should().BeOfType<CustomerCreatedEvent>();
        events.First().As<CustomerCreatedEvent>().FirstName.Should().Be(firstName);
        events.First().As<CustomerCreatedEvent>().LastName.Should().Be(lastName);
        events.First().As<CustomerCreatedEvent>().DateOfBirth.Should().Be(dateOfBirth);
        events.First().As<CustomerCreatedEvent>().PhoneNumber.Should().Be(phoneNumber);
        events.First().As<CustomerCreatedEvent>().Email.Should().Be(email);
        events.First().As<CustomerCreatedEvent>().BankAccountNumber.Should().Be(bankAccountNumber);
    }

    [Fact]
    public async Task Handle_should_throw_CustomerAlreadyExistsException_when_Email_is_already_taken_by_another_User()
    {
        // Arrange
        var existingFirstName = Name.Create("Arash");
        var existingLastName = Name.Create("Doe");
        var existingDateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
        var existingPhoneNumber = Phone.Create("+905317251106");
        var existingEmail = Email.Create("arash@shabbeh.com");
        var existingBankAccountNumber = BankAccountNumber.Create("1234567890");
        var existingCommand = new CreateCustomerCommand(existingFirstName, existingLastName, existingDateOfBirth, existingPhoneNumber, existingEmail, existingBankAccountNumber);
        await _mediator.Send(existingCommand);

        // Act
        var firstName = Name.Create("John");
        var lastName = Name.Create("Doe");
        var dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
        var phoneNumber = Phone.Create("+905317251106");
        var email = existingEmail;
        var bankAccountNumber = BankAccountNumber.Create("1234567890");
        var command = new CreateCustomerCommand(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
        Func<Task> act = async () => await _mediator.Send(command);

        // Assert
        await act.Should().ThrowAsync<CustomerAlreadyExistsException>().WithMessage($"Customer with email {existingEmail.Value} already exists.");

        // Value
        var customers = await _dbContext.Customers.ToListAsync();
        customers.Should().HaveCount(1);
        customers.First().FirstName.Should().Be(existingFirstName.Value);

        // Events
        var events = _eventStore.GetEvents(customers.First().Id);
        events.Should().HaveCount(1);
        events.First().Should().BeOfType<CustomerCreatedEvent>();
        events.First().As<CustomerCreatedEvent>().FirstName.Should().Be(existingFirstName);
    }

    [Fact]
    public async Task Handle_should_throw_CustomerAlreadyExistsException_when_FirstName_LastName_and_DateOfBirth_is_already_taken_by_another_User()
    {
        // Arrange
        var existingFirstName = Name.Create("Arash");
        var existingLastName = Name.Create("Doe");
        var existingDateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
        var existingPhoneNumber = Phone.Create("+905317251106");
        var existingEmail = Email.Create("arash@shabbeh.com");
        var existingBankAccountNumber = BankAccountNumber.Create("1234567890");
        var existingCommand = new CreateCustomerCommand(existingFirstName, existingLastName, existingDateOfBirth, existingPhoneNumber, existingEmail, existingBankAccountNumber);
        await _mediator.Send(existingCommand);

        // Act
        var firstName = existingFirstName;
        var lastName = existingLastName;
        var dateOfBirth = existingDateOfBirth;
        var phoneNumber = Phone.Create("+905317251106");
        var email = Email.Create("arash2@gmail.com");
        var bankAccountNumber = BankAccountNumber.Create("1234567890");
        var command = new CreateCustomerCommand(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
        Func<Task> act = async () => await _mediator.Send(command);

        // Assert
        await act.Should().ThrowAsync<CustomerAlreadyExistsException>().WithMessage($"Customer with name {existingFirstName.Value} {existingLastName.Value} and date of birth {existingDateOfBirth} already exists.");

        // Value
        var customers = await _dbContext.Customers.ToListAsync();
        customers.Should().HaveCount(1);
        customers.First().FirstName.Should().Be(existingFirstName.Value);

        // Events
        var events = _eventStore.GetEvents(customers.First().Id);
        events.Should().HaveCount(1);
        events.First().Should().BeOfType<CustomerCreatedEvent>();
        events.First().As<CustomerCreatedEvent>().FirstName.Should().Be(existingFirstName);
    }
}