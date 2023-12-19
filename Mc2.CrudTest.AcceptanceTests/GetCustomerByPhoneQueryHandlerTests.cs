namespace Mc2.CrudTest.AcceptanceTests;

using System;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Common.Models;
using Mc2.CrudTest.Application.Handlers.QueryHandlers;
using Mc2.CrudTest.Application.Queries;
using ClassLibrary1Mc2.CrudTest.Domain.Entities;
using Moq;
using NUnit.Framework;

[TestFixture]
public class GetCustomerByPhoneQueryHandlerTests
{
    [Test]
    public async Task Handle_ValidPhoneNumber_ReturnsCustomer()
    {
        // Arrange
        var phoneNumber = "1234567890";
        var query = new GetCustomerByPhoneQuery { PhoneNumber = phoneNumber };

        var customerFromRepository = new ClassLibrary1Mc2.CrudTest.Domain.Entities.Customer
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            PhoneNumber = phoneNumber,
            Email = "john.doe@example.com",
            BankAccountNumber = "1234567890123456"
        };

        var customersRepositoryMock = new Mock<ICustomersRepository>();
        customersRepositoryMock
            .Setup(repo => repo.GetCustomerByPhoneAsync(It.IsAny<string>()))
            .ReturnsAsync((ClassLibrary1Mc2.CrudTest.Domain.Entities.Customer?)customerFromRepository);

        var handler = new GetCustomerByPhoneQueryHandler(customersRepositoryMock.Object);

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
}