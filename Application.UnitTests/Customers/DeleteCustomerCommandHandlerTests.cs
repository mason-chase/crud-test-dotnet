using Application.Customers.Commands;
using Application.Customers.Handlers;
using Core.Interfaces;
using Moq;

namespace Application.UnitTests.Customers
{
    public class DeleteCustomerCommandHandlerTests
    {
        [Fact]
        public async Task DeleteCustomerByIdCommandHandler_Should_Delete_Customer()
        {
            // Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            // Setup mock repository
            mockCustomerRepository.Setup(r => r.Delete(It.IsAny<int>()))
                                  .ReturnsAsync((true, ""));

            // Setup mock unit of work
            mockUnitOfWork.Setup(_ => _.CustomerRepository).Returns(mockCustomerRepository.Object);

            var handler = new DeleteCustomerCommandHandler(mockUnitOfWork.Object);

            var command = new DeleteCustomerCommand
            {
                Id = 1
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Item1);
        }

        [Fact]
        public async Task DeleteCustomerByIdCommandHandler_Should_Return_Error_When_Customer_Not_Found()
        {
            // Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            // Setup mock repository
            mockCustomerRepository.Setup(r => r.Delete(It.IsAny<int>()))
                                  .ReturnsAsync((false, ""));

            // Setup mock unit of work
            mockUnitOfWork.Setup(_ => _.CustomerRepository).Returns(mockCustomerRepository.Object);

            var handler = new DeleteCustomerCommandHandler(mockUnitOfWork.Object);

            var command = new DeleteCustomerCommand
            {
                Id = 1
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Item1);
        }
    }
}
