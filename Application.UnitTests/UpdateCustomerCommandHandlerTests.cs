using Application.Customers.Commands;
using Application.Customers.Handlers;
using Core.Interfaces;
using Core.Models;
using Moq;

namespace Application.UnitTests
{
    public class UpdateCustomerCommandHandlerTests
    {
        [Fact]
        public async Task UpdateCustomerCommandHandler_Should_Update_Customer()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(_ => _.CustomerRepository.Update(It.IsAny<Customer>())).Returns(true);
            var handler = new UpdateCustomerCommandHandler(mockUnitOfWork.Object);

            var command = new UpdateCustomerCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com",
                BankAccountNumber = "1234567890123456"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Item1);
        }

    }
}