using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Command;

namespace Mc2.CrudTest.Application.Commands.Handlers
{
    internal sealed class AddCustomerHandler : ICommandHandler<AddCustomer>
    {
        private readonly ICustomerRepository _repository;
        private readonly ICustomerFactory _factory;
        private readonly ICustomerReadService _customerReadService;
        public AddCustomerHandler(
            ICustomerRepository repository,
            ICustomerFactory factory,
            ICustomerReadService customerReadService)
        {
            _repository = repository;
            _factory = factory;
            _customerReadService = customerReadService;
        }

        public async Task Handle(AddCustomer command)
        {
            var birtday=DateOnly.Parse(command.Birthday);
            bool alreadyExists = await _customerReadService.Exists(command.FullName.FirstName, command.FullName.LastName, birtday);
            if(alreadyExists)
            {
                throw new CustomerAlreadyExists(command.FullName.FirstName, command.FullName.LastName, birtday);
            }
            bool alreadyExistsEmail = await _customerReadService.Exists(command.email,command.Id);
            if (alreadyExistsEmail)
            {
                throw new CustomerAlreadyExists(command.email);
            }
            var fullName=new CustomerFullName(command.FullName.FirstName,command.FullName.LastName);
            var customerNew = _factory.Create(Guid.NewGuid(), fullName, birtday, command.email, command.bankAccountNumber, command.phoneNumber);
            await _repository.Add(customerNew);

        }
    }
}
