using Mc2.CrudTest.Shared.Abstraction.Command;
using NSubstitute;
using Shouldly;
using Mc2.CrudTest.Application.Commands.Handlers;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Exceptions;

namespace Mc2.CrudTest.Tests.Application
{
    public class CustomerExistanceTests
    {
        Task Act(AddCustomer command)
           => _commandHandler.Handle(command);

        [Fact]
        public async Task Test_Already_Exists_Customer()
        {
            FullNameWriteModel fullNameWriteModel = new FullNameWriteModel("mason", "chase");
            var guid= Guid.NewGuid();
            var command = new AddCustomer(guid,fullNameWriteModel,"1991-04-04","info@gmail.com", "DE08700901001234567890","09135742556");
            _readService.Exists("mason", "chase", DateOnly.Parse("1991-04-04")).Returns(true);

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<CustomerAlreadyExists>();
        }

        #region ARRANGE

        private readonly ICommandHandler<AddCustomer> _commandHandler;
        private readonly ICustomerRepository _repository;
        private readonly ICustomerReadService _readService;
        private readonly ICustomerFactory _factory;

        public CustomerExistanceTests()
        {
            _repository = Substitute.For<ICustomerRepository>();
            _readService = Substitute.For<ICustomerReadService>();
            _factory = Substitute.For<ICustomerFactory>();
            _commandHandler = new AddCustomerHandler(_repository, _factory, _readService);
        }

        #endregion
    }
}
