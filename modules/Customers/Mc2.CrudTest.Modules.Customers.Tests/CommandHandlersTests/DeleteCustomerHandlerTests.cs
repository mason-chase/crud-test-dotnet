using System.Linq.Expressions;
using FluentAssertions;
using Mc2.CrudTest.Modules.Customers.Application.CommandHandlers;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.CreateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.DeleteCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.UpdateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Exceptions;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Modules.Customers.Tests.Utils;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;
using NSubstitute;

namespace Mc2.CrudTest.Modules.Customers.Tests.CommandHandlersTests;

public class DeleteCustomerHandlerTests
{
    private IEventStore _eventStore = Substitute.For<IEventStore>();
    private IRepository<Customer, CustomerId> _repository = Substitute.For<IRepository<Customer, CustomerId>>();
    private DeleteCustomerHandler Sut => new DeleteCustomerHandler(_repository, _eventStore);

    private readonly Customer _aggregate;
    private readonly DeleteCustomerCommand _command;

    public DeleteCustomerHandlerTests()
    {
        var firstName = Name.Create("John");
        var lastName = Name.Create("Doe");
        var dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
        var phoneNumber = Phone.Create("+905317251106");
        var email = Email.Create("arash@shabbeh.com");
        var bankAccountNumber = BankAccountNumber.Create("1234567890");

        _aggregate = Customer.Create(new CustomerCreatedEvent(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));
        _command = new DeleteCustomerCommand(new CustomerId(1));
    }

    [Fact]
    public async Task Handle_should_cause_Updating_Customer_in_Repository_and_Committing_Events()
    {
        // Arrange
        _repository
            .AnyAsync(Arg.Any<Expression<Func<Customer, bool>>>(), Arg.Any<CancellationToken>())
            .Returns(false);
        _repository.SingleOrDefaultAsync(Arg.Any<Expression<Func<Customer, bool>>>(), Arg.Any<CancellationToken>())
            .Returns(_aggregate);

        // Act
        await Sut.Handle(_command, CancellationToken.None);

        // Assert
        _repository.Received(1).Remove(Arg.Any<Customer>());
        await _repository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        _eventStore.Received(1).Commit(Arg.Any<int>(), Arg.Any<IEnumerable<IDomainEvent>>());
    }

    [Fact]
    public async Task Handle_should_throw_CustomerNotFoundException_when_Customer_is_not_found()
    {
        // Arrange
        _repository.SingleOrDefaultAsync(Arg.Any<Expression<Func<Customer, bool>>>(), Arg.Any<CancellationToken>())
            .Returns((Customer?)null);

        // Act
        var customerId = async () => await Sut.Handle(_command, CancellationToken.None);

        // Assert
        await customerId.Should().ThrowAsync<CustomerNotFoundException>();
        await _repository.Received(1).SingleOrDefaultAsync(Arg.Any<Expression<Func<Customer, bool>>>(), Arg.Any<CancellationToken>());
    }
}