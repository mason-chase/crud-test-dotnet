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
public class UpdateCustomerCommandHandlerTests
{
    [Test]
    public async Task Handle_ValidCommand_ReturnsTrue()
    {
        // Arrange
        var validPhoneNumber = "+447480973809";
        var validEmail = "john.doe@example.com";
        var validBankAccountNumber = "6037991757147651";

        var command = new UpdateCustomerCommand
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            PhoneNumber = validPhoneNumber,
            Email = validEmail,
            BankAccountNumber = validBankAccountNumber
        };

        
        var customersRepositoryMock = new Mock<ICustomersRepository>();
        customersRepositoryMock
            .Setup(repo => repo.UpdateCustomerAsync(It.IsAny<Customer>()))
            .ReturnsAsync(true); 

        var handler = new UpdateCustomerCommandHandler(customersRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void Handle_InvalidPhoneNumber_ThrowValidationException()
    {
        // Arrange
        var invalidPhoneNumber = "invalid"; // Invalid phone number

        var command = new UpdateCustomerCommand
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            PhoneNumber = invalidPhoneNumber,
            Email = "john.doe@example.com",
            BankAccountNumber = "1234567890123456"
        };

        var customersRepositoryMock = new Mock<ICustomersRepository>();
        var handler = new UpdateCustomerCommandHandler(customersRepositoryMock.Object);

        // Act and Assert
        FluentActions.Invoking(async () => await handler.Handle(command, CancellationToken.None))
            .Should().ThrowAsync<ValidationException>().WithMessage("Invalid phone number.");
    }

    [Test]
    public void Handle_InvalidEmail_ThrowsValidationException()
    {
        // Arrange
        var invalidEmail = "invalid-email"; // Invalid email

        var command = new UpdateCustomerCommand
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            PhoneNumber = "1234567890",
            Email = invalidEmail,
            BankAccountNumber = "1234567890123456"
        };

        var customersRepositoryMock = new Mock<ICustomersRepository>();
        var handler = new UpdateCustomerCommandHandler(customersRepositoryMock.Object);

        // Act and Assert
        FluentActions.Invoking(async () => await handler.Handle(command, CancellationToken.None))
            .Should().ThrowAsync<ValidationException>().WithMessage("Invalid email address.");
    }

    [Test]
    public void Handle_InvalidBankAccountNumber_ThrowsValidationException()
    {
        // Arrange
        var invalidBankAccountNumber = "invalid"; // Invalid bank account number

        var command = new UpdateCustomerCommand
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            PhoneNumber = "1234567890",
            Email = "john.doe@example.com",
            BankAccountNumber = invalidBankAccountNumber
        };

        var customersRepositoryMock = new Mock<ICustomersRepository>();
        var handler = new UpdateCustomerCommandHandler(customersRepositoryMock.Object);

        // Act and Assert
        FluentActions.Invoking(async () => await handler.Handle(command, CancellationToken.None))
            .Should().ThrowAsync<ValidationException>().WithMessage("Invalid bank account number.");
    }

   
}
