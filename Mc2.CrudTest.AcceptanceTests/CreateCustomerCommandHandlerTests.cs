using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Common.Models;
using Mc2.CrudTest.Application.Handlers.CommandHandlers;
using ClassLibrary1Mc2.CrudTest.Domain.Entities;
using Moq;
using NUnit.Framework;
using Customer = ClassLibrary1Mc2.CrudTest.Domain.Entities.Customer;

[TestFixture]
public class CreateCustomerCommandHandlerTests
{

    [Test]
    public void Handle_InvalidPhoneNumber_ThrowsValidationException()
    {
        // Arrange
        var invalidPhoneNumber = "invalid"; // Invalid phone number

        var command = new CreateCustomerCommand
        {
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            PhoneNumber = invalidPhoneNumber,
            Email = "john.doe@example.com",
            BankAccountNumber = "1234567890123456"
        };

        var customersRepositoryMock = new Mock<ICustomersRepository>();
        var handler = new CreateCustomerCommandHandler(customersRepositoryMock.Object);

        // Act and Assert
        FluentActions.Invoking(async () => await handler.Handle(command, CancellationToken.None))
            .Should().ThrowAsync<ValidationException>().WithMessage("Invalid phone number.");
    }

    [Test]
    public void Handle_InvalidEmail_ThrowsValidationException()
    {
        // Arrange
        var invalidEmail = "invalid-email"; // Invalid email

        var command = new CreateCustomerCommand
        {
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            PhoneNumber = "1234567890",
            Email = invalidEmail,
            BankAccountNumber = "1234567890123456"
        };

        var customersRepositoryMock = new Mock<ICustomersRepository>();
        var handler = new CreateCustomerCommandHandler(customersRepositoryMock.Object);

        // Act and Assert
        FluentActions.Invoking(async () => await handler.Handle(command, CancellationToken.None))
            .Should().ThrowAsync<ValidationException>().WithMessage("Invalid email address.");
    }

    [Test]
    public void Handle_InvalidBankAccountNumber_ThrowsValidationException()
    {
        // Arrange
        var invalidBankAccountNumber = "invalid"; // Invalid bank account number

        var command = new CreateCustomerCommand
        {
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            PhoneNumber = "1234567890",
            Email = "john.doe@example.com",
            BankAccountNumber = invalidBankAccountNumber
        };

        var customersRepositoryMock = new Mock<ICustomersRepository>();
        var handler = new CreateCustomerCommandHandler(customersRepositoryMock.Object);

        // Act and Assert
        FluentActions.Invoking(async () => await handler.Handle(command, CancellationToken.None))
            .Should().ThrowAsync<ValidationException>().WithMessage("Invalid bank account number.");
    }
}
