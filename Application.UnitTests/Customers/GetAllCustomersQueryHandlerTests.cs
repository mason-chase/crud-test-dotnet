using Application.Customers.Handlers;
using Application.Customers.Queries;
using Core.Interfaces;
using Core.Models;
using Moq;

namespace Application.UnitTests.Customers
{
    public class GetAllCustomersQueryHandlerTests
    {
        [Fact]
        public async Task GetAllCustomersQueryHandler_Should_Return_Customer()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(r => r.CustomerRepository.GetAll()).ReturnsAsync(new List<Customer> { });

            var handler = new GetAllCustomersQueryHandler(mockUnitOfWork.Object);
            var query = new GetAllCustomersQuery { };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllCustomersQueryHandler_Should_Return_Null_When_There_Is_No_Customers()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(r => r.CustomerRepository.GetAll()).ReturnsAsync(() => null);

            var handler = new GetAllCustomersQueryHandler(mockUnitOfWork.Object);
            var query = new GetAllCustomersQuery { };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
    }
}