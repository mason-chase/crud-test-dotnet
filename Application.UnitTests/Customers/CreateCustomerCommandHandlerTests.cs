using Application.Customers.Commands;
using Application.Customers.Handlers;
using Core.Interfaces;
using Core.Models;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Application.UnitTests.Customers
{
    public class CreateCustomerCommandHandlerTests
    {
        [Fact]
        public async Task CreateCustomerCommandHandler_Should_Add_Customer()
        {
            // Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            // Setup mock repository
            mockCustomerRepository.Setup(r => r.Add(It.IsAny<Customer>()))
                                  .Callback<Customer>(_ => _.Id = 1);//Just an Id bigger than zero

            // Setup mock unit of work
            mockUnitOfWork.Setup(_ => _.CustomerRepository).Returns(mockCustomerRepository.Object);

            var handler = new CreateCustomerCommandHandler(mockUnitOfWork.Object);

            var command = new CreateCustomerCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "+1 (650) 253-0000",
                Email = "john.doe@example.com",
                BankAccountNumber = "100200300400"
            };
            var context = new ValidationContext(command);
            var results = new List<ValidationResult>();
            // Act

            var isValid = Validator.TryValidateObject(command, context, results, true);
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(isValid);
            Assert.True(result.Item1 > 0);
        }

        [Fact]
        public async Task CreateCustomerCommandHandler_With_Duplicate_Email_Should_Return_BadRequest()
        {
            // Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var existingCustomerWithEmail = new Customer { Email = "existing@example.com" };
            // Setup mock repository
            mockCustomerRepository.Setup(r => r.FindByEmail(It.IsAny<string>()))
                                  .ReturnsAsync(existingCustomerWithEmail);//Just an Id bigger than zero

            // Setup mock unit of work
            mockUnitOfWork.Setup(_ => _.CustomerRepository).Returns(mockCustomerRepository.Object);

            var handler = new CreateCustomerCommandHandler(mockUnitOfWork.Object);

            var command = new CreateCustomerCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Now,
                Email = "existing@example.com",
                BankAccountNumber = "1234567890123456"
            };
            // Act

            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal((0, "Email already exists."), result);
        }

        [Fact]
        public async Task CreateCustomerCommandHandler_With_Duplicate_Details_Should_Return_BadRequest()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var customerRepositoryMock = new Mock<ICustomerRepository>();

            var existingCustomerWithDetails = new Customer { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 1, 1) };
            customerRepositoryMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<Customer, bool>>>())).ReturnsAsync(existingCustomerWithDetails);

            unitOfWorkMock.SetupGet(u => u.CustomerRepository).Returns(customerRepositoryMock.Object);

            var handler = new CreateCustomerCommandHandler(unitOfWorkMock.Object);

            var request = new CreateCustomerCommand { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 1, 1) };

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal((0, "Customer with the same details already exists."), result);
        }

        [Fact]
        public async Task CreateCustomerCommandHandler_Should_Return_False_When_PhoneNumber_Is_Not_Valid()
        {
            // Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            // Setup mock repository
            mockCustomerRepository.Setup(r => r.Add(It.IsAny<Customer>()))
                                  .Callback<Customer>(_ => _.Id = 0);

            // Setup mock unit of work
            mockUnitOfWork.Setup(uow => uow.CustomerRepository).Returns(mockCustomerRepository.Object);

            var handler = new CreateCustomerCommandHandler(mockUnitOfWork.Object);

            var command = new CreateCustomerCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "(650) 253-0000",
                Email = "john.doe@example.com",
                BankAccountNumber = "1234567890123456"
            };
            var context = new ValidationContext(command);
            var results = new List<ValidationResult>();
            // Act

            var isValid = Validator.TryValidateObject(command, context, results, true);
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(isValid);
            Assert.False(result.Item1 > 0);
        }

    }
}