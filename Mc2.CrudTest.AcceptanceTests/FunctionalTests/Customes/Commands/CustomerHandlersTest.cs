using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Common.Models;
using Mc2.CrudTest.Presentation.Application.Customers.Commands.AddCustomer;
using Mc2.CrudTest.Presentation.Application.Customers.Commands.DeleteCustomer;
using Mc2.CrudTest.Presentation.Application.Customers.Commands.UpdateCustomer;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCustomerById;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCustomers;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.IsExistCustomer;
using Mc2.CrudTest.Presentation.Domain.Entities;
using Mc2.CrudTest.Presentation.Infrastructure.Data;

using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.FunctionalTests.Customes.Commands
{
    public class CustomerHandlersTest
    {
        private readonly IFixture fixture;
        private ICommandRepository _commandRepository;
        CancellationToken cancellationToken;
        private IEnumerable<Customer> fakeCustomers;

        public CustomerHandlersTest()
        {
            //Arrange
            fixture = new Fixture().Customize(new AutoMoqCustomization());

            fakeCustomers = fixture.CreateMany<Customer>();
            Mock<ApplicationDbContext> mockDemoContext = new();
            mockDemoContext.Setup(context => context.Set<Customer>()).ReturnsDbSet(fakeCustomers);

            CommandRepository commandRepository = new(mockDemoContext.Object);

            _commandRepository = commandRepository;

        }


        [Fact]
        public async void AddCustomer_InsertNewCustomer_ReturnCustomerModel()
        {
            //Arrange
            var customerModel = new AddCustomerCommand(fixture.Create<CustomerModel>());

            //Act
            var handler = new AddCustomerCommandHandler(_commandRepository);

            var result = await handler.Handle(customerModel, cancellationToken);

            //Assert
            result.Should().BeOfType<Result<CustomerModel>>();

            result.Status.Should().Be(ResultStatusEnum.Succeeded);
        }
        [Fact]
        public async void UpdateCustomer_EditExistedCustomer_ReturnCustomerModel()
        {
            //Arrange
            var customerModel = new UpdateCustomerCommand(fixture.Create<CustomerModel>());

            //Act
            var handler = new UpdateCustomerCommandHandler(_commandRepository);

            var result = await handler.Handle(customerModel, cancellationToken);

            //Assert
            result.Should().BeOfType<Result<CustomerModel>>();

            result.Status.Should().Be(ResultStatusEnum.Succeeded);

        }
        [Fact]
        public async void DeleteCustomer_RemoveCustomer_ReturnResult()
        {
            //Arrange
            var id = fakeCustomers.First().Id;

            //Act
            var handler = new DeleteCustomerCommandHandler(_commandRepository);

            var command = new DeleteCustomerCommand(id);

            var result = await handler.Handle(command, cancellationToken);

            //Assert
            result.Should().BeOfType<Result>();

            result.Status.Should().Be(ResultStatusEnum.Succeeded);

        }

    }

}

