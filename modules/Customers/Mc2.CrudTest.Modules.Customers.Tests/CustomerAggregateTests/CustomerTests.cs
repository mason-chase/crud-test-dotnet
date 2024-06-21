using FluentAssertions;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.CreateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.DeleteCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.UpdateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Models;

namespace Mc2.CrudTest.Modules.Customers.Tests.CustomerAggregateTests;

public class CustomerTests
{
    [Fact]
    public void Create_should_Create_a_Customer_Aggregate()
    {
        // Arrange
        var firstName = Name.Create("John");
        var lastName = Name.Create("Doe");
        var dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
        var phoneNumber = Phone.Create("+905317251106");
        var email = Email.Create("arash@shabbhe.com");
        var bankAccountNumber = BankAccountNumber.Create("1234567890");

        // Act
        var agg = Customer.Create(new CustomerCreatedEvent(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        // Assert
        agg.Events.Should().ContainSingle();

        var @event = agg.Events.First();
        @event.Should().BeOfType<CustomerCreatedEvent>();

        agg.FirstName.Should().Be(firstName.Value);
        agg.LastName.Should().Be(lastName.Value);
        agg.DateOfBirth.Should().Be(dateOfBirth.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc));
        agg.PhoneNumber.Should().Be(phoneNumber.Value);
        agg.Email.Should().Be(email.Value);
        agg.BankAccountNumber.Should().Be(bankAccountNumber.Value);
    }

    [Fact]
    public void Update_should_Update_a_Customer_Aggregate()
    {
        // Arrange
        var firstName = Name.Create("John");
        var lastName = Name.Create("Doe");
        var dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
        var phoneNumber = Phone.Create("+905317251106");
        var email = Email.Create("arash@shabbeh.com");
        var bankAccountNumber = BankAccountNumber.Create("1234567890");

        var agg = Customer.Create(new CustomerCreatedEvent(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        var updatedFirstName = Name.Create("Jane");
        var updatedLastName = Name.Create("Doe");
        agg.AppendEvent(new CustomerUpdatedEvent(updatedFirstName, updatedLastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        // Act
        agg.Events.Should().HaveCount(2);

        agg.Events.First().Should().BeOfType<CustomerCreatedEvent>();

        var @event = agg.Events.Last();
        @event.Should().BeOfType<CustomerUpdatedEvent>();

        agg.FirstName.Should().Be(updatedFirstName.Value);
        agg.LastName.Should().Be(updatedLastName.Value);
        agg.DateOfBirth.Should().Be(dateOfBirth.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc));
        agg.PhoneNumber.Should().Be(phoneNumber.Value);
        agg.Email.Should().Be(email.Value);
        agg.BankAccountNumber.Should().Be(bankAccountNumber.Value);
    }

    [Fact]
    public void Delete_should_Delete_a_Customer_Aggregate()
    {
        // Arrange
        var firstName = Name.Create("John");
        var lastName = Name.Create("Doe");
        var dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
        var phoneNumber = Phone.Create("+905317251106");
        var email = Email.Create("arash@shabbeh.com");
        var bankAccountNumber = BankAccountNumber.Create("1234567890");

        var agg = Customer.Create(new CustomerCreatedEvent(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        // Act
        agg.AppendEvent(new CustomerDeletedEvent());

        // Assert
        agg.IsDeleted.Should().BeTrue();

        agg.Events.Should().HaveCount(2);
        agg.Events.Last().Should().BeOfType<CustomerDeletedEvent>();
    }
}