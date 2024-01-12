using System;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Common.Models;
using Mc2.CrudTest.Application.Handlers.QueryHandlers;
using Mc2.CrudTest.Application.Queries;
using Moq;
using NUnit.Framework;
using ClassLibrary1Mc2.CrudTest.Domain.Entities;
using Customer = ClassLibrary1Mc2.CrudTest.Domain.Entities.Customer;

[TestFixture]
public class GetCustomerByIdQueryHandlerTests
{
    [Test]
    public async Task Handle_ValidId_ReturnsCustomer()
    {
        // Arrange
        var customerId = 1;
        var query = new GetCustomerByIdQuery { Id = customerId };

        var customerFromRepository = new Customer
        {
            Id = customerId,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            PhoneNumber = "1234567890",
            Email = "john.doe@example.com",
            BankAccountNumber = "1234567890123456"
        };

        var customersRepositoryMock = new Mock<ICustomersRepository>();
        customersRepositoryMock
            .Setup(repo => repo.GetCustomerByIdAsync(It.IsAny<long>()))
            .ReturnsAsync(customerFromRepository);

        var handler = new GetCustomerByIdQueryHandler(customersRepositoryMock.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(customerFromRepository.Id, result.Id);
        Assert.AreEqual(customerFromRepository.FirstName, result.FirstName);
        Assert.AreEqual(customerFromRepository.LastName, result.LastName);
        Assert.AreEqual(customerFromRepository.DateOfBirth, result.DateOfBirth);
        Assert.AreEqual(customerFromRepository.PhoneNumber, result.PhoneNumber);
        Assert.AreEqual(customerFromRepository.Email, result.Email);
        Assert.AreEqual(customerFromRepository.BankAccountNumber, result.BankAccountNumber);
    }

    [Test]
    public async Task Handle_InvalidId_ReturnsNull()
    {
        // Arrange
        var customerId = 2; // Assuming an ID that does not exist
        var query = new GetCustomerByIdQuery { Id = customerId };

        var customersRepositoryMock = new Mock<ICustomersRepository>();
        customersRepositoryMock
            .Setup(repo => repo.GetCustomerByIdAsync(It.IsAny<long>()))
            .ReturnsAsync((Customer)null); // Simulate no customer found

        var handler = new GetCustomerByIdQueryHandler(customersRepositoryMock.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.IsNull(result);
    }
}
