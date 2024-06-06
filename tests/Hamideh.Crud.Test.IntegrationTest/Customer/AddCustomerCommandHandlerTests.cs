using Hamideh.Crud.Test.IntegrationTests.Fixtures;
using FluentAssertions;
using Hamideh.Crud.Test.Application.CustomerFeatures.Command.AddCustomer;
using Hamideh.Crud.Test.Infrastracture.Repositories;

namespace Hamideh.Crud.Test.IntegrationTest.Customer
{
    public class AddCustomerCommandHandlerTests : IClassFixture<CustomerDbContextFixture>
    {
        private readonly CustomerDbContextFixture _fixture;

        public AddCustomerCommandHandlerTests(CustomerDbContextFixture fixture)
        {
            _fixture = fixture;
        }



        [Fact]
        public async Task Handle_ShouldAddCustomer_WhenParametersAreValid()
        {
            // Arrange
            var articleRepository = new CustomerRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
            var _sut = new AddCustomerCommandHandler(articleRepository);
            var command = new AddCustomerCommand()
            {
                FirstName = "Hamideh",
                LastName = "Bisayar",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "+989150063651",
                Email = "hamidebisayar@gmail.com",
                BankAccountNumber = "145-897-85"
            };

            // Act
            var response = await _sut.Handle(command, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.FirstName.Should().Be("Hamideh");
            response.PhoneNumber.Should().Be("+989150063651");
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenEmailIsInvalid()
        {
            // Arrange
            var articleRepository = new CustomerRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
            var _sut = new AddCustomerCommandHandler(articleRepository);
            var command = new AddCustomerCommand()
            {
                FirstName = "Hamideh",
                LastName = "Bisayar",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "+989150063651",
                Email = "hamide@bisayar@gmail.com",
                BankAccountNumber = "145-897-85"
            };

            // Act
            Func<Task> act = async () => await _sut.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<Exception>();
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenPhoneNumberIsInvalid()
        {
            // Arrange
            var articleRepository = new CustomerRepository(_fixture.BuildDbContext(Guid.NewGuid().ToString()));
            var _sut = new AddCustomerCommandHandler(articleRepository);
            var command = new AddCustomerCommand()
            {
                FirstName = "Hamideh",
                LastName = "Bisayar",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "063651",
                Email = "hamidebisayar@gmail.com",
                BankAccountNumber = "145-897-85"
            };

            // Act
            Func<Task> act = async () => await _sut.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<Exception>();
        }
    }
}