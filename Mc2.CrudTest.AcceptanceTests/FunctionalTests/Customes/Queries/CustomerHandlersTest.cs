using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Common.Models;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCustomerById;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCustomers;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.IsExistCustomer;
using Mc2.CrudTest.Presentation.Domain.Entities;
using Mc2.CrudTest.Presentation.Infrastructure.Data;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.FunctionalTests.Customes.Queries
{
    public class CustomerHandlersTest
    {
        private readonly IFixture fixture;
        private IQueryRepository _queryRepository;
        CancellationToken cancellationToken;
        private IEnumerable<Customer> fakeCustomers;

        public CustomerHandlersTest()
        {
            //Arrange
            fixture = new Fixture().Customize(new AutoMoqCustomization());

            fakeCustomers = fixture.CreateMany<Customer>();
            Mock<ApplicationDbContext> mockDemoContext = new();
            mockDemoContext.Setup(context => context.Set<Customer>()).ReturnsDbSet(fakeCustomers);

            QueryRepository queryRepository = new(mockDemoContext.Object);

            _queryRepository = queryRepository;

        }


        [Fact]
        public async void GetCustomers_RetrieveAllCustomers_ReturnCustomerModelList()
        {
            //Act
            var handler = new GetCustomersQueryHandler(_queryRepository);

            var query = new GetCustomersQuery();

            var result = await handler.Handle(query, cancellationToken);

            //Assert
            result.Should().BeOfType<Result<List<CustomerModel>>>();

            result.Status.Should().Be(ResultStatusEnum.Succeeded);

        }

        [Fact]
        public async void GetCustomer_RetrieveCustomerById_ReturnCustomerModel()
        {
            //Arrange
            var id = fakeCustomers.First().Id;

            //Act
            var handler = new GetCustomerByIdQueryHandler(_queryRepository);


            var query = new GetCustomerByIdQuery(id);

            var result = await handler.Handle(query, cancellationToken);

            //Assert
            result.Should().BeOfType<Result<CustomerModel>>();

            result.Status.Should().Be(ResultStatusEnum.Succeeded);

        }

        [Fact]
        public async void IsExistCustomerEmail_CheckEmailExist_ReturnResult()
        {
            //Arrange
            var email = fakeCustomers.First().Email;

            //Act
            var handler = new IsExistCustomerEmailQueryHandler(_queryRepository);

            var query = new IsExistCustomerEmailQuery(email);

            var result = await handler.Handle(query, cancellationToken);

            //Assert
            result.Should().BeOfType<Result<bool>>();

            result.Status.Should().Be(ResultStatusEnum.Succeeded);

            result.Data.Should().Be(true);

        }

        [Fact]
        public async void IsExistCustomerEmail_CheckEmailNotExistForEditOperation_ReturnResult()
        {
            //Arrange
            var email = fakeCustomers.First().Email;
            var id = fakeCustomers.First().Id;

            //Act
            var handler = new IsExistCustomerEmailForUpdateQueryHandler(_queryRepository);

            var query = new IsExistCustomerEmailForUpdateQuery(id, email);

            var result = await handler.Handle(query, cancellationToken);

            //Assert
            result.Should().BeOfType<Result<bool>>();

            result.Status.Should().Be(ResultStatusEnum.Succeeded);

            result.Data.Should().Be(false);

        }

        [Fact]
        public async void IsExistCustomerName_CheckFirstNameLastNameBirthDateExist_ReturnResult()
        {
            //Arrange
            var firstName = fakeCustomers.First().FirstName;
            var lastName = fakeCustomers.First().LastName;
            var dateOfBirth = fakeCustomers.First().DateOfBirth;

            //Act
            var handler = new IsExistCustomerNameQueryHandler(_queryRepository);

            var query = new IsExistCustomerNameQuery(firstName, lastName, dateOfBirth);

            var result = await handler.Handle(query, cancellationToken);

            //Assert
            result.Should().BeOfType<Result<bool>>();

            result.Status.Should().Be(ResultStatusEnum.Succeeded);

            result.Data.Should().Be(true);

        }

        [Fact]
        public async void IsExistCustomerName_CheckFirstNameLastNameBirthDateExistForEditOperation_ReturnResult()
        {
            //Arrange
            var id = fakeCustomers.First().Id;
            var firstName = fakeCustomers.First().FirstName;
            var lastName = fakeCustomers.First().LastName;
            var dateOfBirth = fakeCustomers.First().DateOfBirth;

            //Act
            var handler = new IsExistCustomerNameForUpdateQueryHandler(_queryRepository);

            var query = new IsExistCustomerNameForUpdateQuery(id, firstName, lastName, dateOfBirth);

            var result = await handler.Handle(query, cancellationToken);

            //Assert
            result.Should().BeOfType<Result<bool>>();

            result.Status.Should().Be(ResultStatusEnum.Succeeded);

            result.Data.Should().Be(false);

        }

    }

}

