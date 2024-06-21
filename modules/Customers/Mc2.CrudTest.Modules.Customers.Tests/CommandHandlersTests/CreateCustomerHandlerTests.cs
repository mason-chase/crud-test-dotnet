using System.Linq.Expressions;
using FluentAssertions;
using Mc2.CrudTest.Modules.Customers.Application.CommandHandlers;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.CreateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Exceptions;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Modules.Customers.Tests.Utils;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;
using NSubstitute;

namespace Mc2.CrudTest.Modules.Customers.Tests.CommandHandlersTests;

public class CreateCustomerHandlerTests
{
    private IEventStore _eventStore = Substitute.For<IEventStore>();
    private IRepository<Customer, CustomerId> _repository = Substitute.For<IRepository<Customer, CustomerId>>();
    private CreateCustomerHandler Sut => new CreateCustomerHandler(_repository, _eventStore);

    private readonly CreateCustomerCommand _command;

    public CreateCustomerHandlerTests()
    {
        var firstName = Name.Create("John");
        var lastName = Name.Create("Doe");
        var dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);
        var phoneNumber = Phone.Create("+905317251106");
        var email = Email.Create("arash@shabbeh.com");
        var bankAccountNumber = BankAccountNumber.Create("1234567890");

        _command = new CreateCustomerCommand(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
    }

    [Fact]
    public async Task Handle_should_throw_CustomerAlreadyExistsException_when_Email_is_already_taken_by_another_Customer()
    {
        // Arrange
        _repository
            .AnyAsync(Arg.Is<Expression<Func<Customer, bool>>>(s =>
                LambdaCompare.Eq(s, e => e.Email == _command.Email.Value)), Arg.Any<CancellationToken>())
            .Returns(true);

        // Act
        var customerId = async () => await Sut.Handle(_command, CancellationToken.None);

        // Assert
        await customerId.Should().ThrowAsync<CustomerAlreadyExistsException>();
        await _repository.Received(1).AnyAsync(Arg.Any<Expression<Func<Customer, bool>>>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_should_throw_CustomerAlreadyExistsException_when_FirstName_LastName_and_DateOfBirth_is_already_taken_by_another_Customer()
    {
        // Arrange
        _repository
            .AnyAsync(Arg.Is<Expression<Func<Customer, bool>>>(s =>
                LambdaCompare.Eq(s, e => e.FirstName == _command.FirstName.Value && e.LastName == _command.LastName.Value && e.DateOfBirth == _command.DateOfBirth.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc))), Arg.Any<CancellationToken>())
            .Returns(true);

        // Act
        var customerId = async () => await Sut.Handle(_command, CancellationToken.None);

        // Assert
        await customerId.Should().ThrowAsync<CustomerAlreadyExistsException>();
        await _repository.Received(2).AnyAsync(Arg.Any<Expression<Func<Customer, bool>>>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_should_cause_Adding_Customer_to_Repository_and_Committing_Events()
    {
        // Arrange
        _repository
            .AnyAsync(Arg.Any<Expression<Func<Customer, bool>>>(), Arg.Any<CancellationToken>())
            .Returns(false);

        // Act
        var customerId = await Sut.Handle(_command, CancellationToken.None);

        // Assert
        _repository.Received(1).Add(Arg.Any<Customer>());
        await _repository.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        _eventStore.Received(1).Commit(Arg.Any<int>(), Arg.Any<IEnumerable<IDomainEvent>>());
        customerId.Should().NotBeNull();
    }
}