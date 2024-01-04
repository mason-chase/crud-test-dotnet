
using Mc2.CrudTest.Core.Domain.Customers.Commands;
using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Mc2.CrudTest.Core.Domain.Customers.ValueObjects;
using Mc2.CrudTest.Framework.Domain.ApplicationService;

namespace Mc2.CrudTest.Core.ApplicationService.Customers.CommandHandlers
{
    public class CreateCustomerCommandHandler :ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Handle(CreateCustomerCommand command)
        {
            if (_customerRepository.Exists(command.Id))
                throw new InvalidOperationException($"The Customer with id:{command.Id} already exists.");

            var customer = new Customer(command.Id, 
                                        command.FirstName,
                                        command.LastName,
                                        Email.FromString(command.Email),
                                        PhoneNumber.FromString(command.PhoneNumber),
                                        BankAccountNumber.FromString(command.BankAccountNumber),
                                        command.DateOfBirth);
            _customerRepository.Save(customer);
           // unitOfWork.Commit();
        }
    }
}
