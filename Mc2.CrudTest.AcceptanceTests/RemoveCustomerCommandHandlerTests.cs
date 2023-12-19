using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Handlers.CommandHandlers;
using Moq;
using NUnit.Framework;
using ClassLibrary1Mc2.CrudTest.Domain.Entities;

[TestFixture]
public class RemoveCustomerCommandHandlerTests
{
    [Test]
    public async Task Handle_ValidCommand_ReturnsTrue()
    {
        // Arrange
        var customerId = 1;

        var command = new RemoveCustomerCommand
        {
            Id = customerId
        };

        
        var customersRepositoryMock = new Mock<ICustomersRepository>();
        customersRepositoryMock
            .Setup(repo => repo.RemoveCustomerAsync(It.IsAny<long>()))
            .ReturnsAsync(true); 

        var handler = new RemoveCustomerCommandHandler(customersRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public async Task Handle_InvalidCommand_ReturnsFalse()
    {
        // Arrange
        var customerId = 2; 
        var command = new RemoveCustomerCommand
        {
            Id = customerId
        };

        
        var customersRepositoryMock = new Mock<ICustomersRepository>();
        customersRepositoryMock
            .Setup(repo => repo.RemoveCustomerAsync(It.IsAny<long>()))
            .ReturnsAsync(false); 

        var handler = new RemoveCustomerCommandHandler(customersRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeFalse();
    }

    
}