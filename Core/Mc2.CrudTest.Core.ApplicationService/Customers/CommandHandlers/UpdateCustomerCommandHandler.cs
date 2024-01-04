using Mc2.CrudTest.Core.Domain.Customers.Commands;
using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Core.Domain.Customers.ValueObjects;
using Mc2.CrudTest.Framework.Domain.ApplicationService;

namespace Mc2.CrudTest.Core.ApplicationService.Customers.CommandHandlers
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Handle(UpdateCustomerCommand command)
        {
            var customer = _customerRepository.Load(command.Id);

            if (customer == null)
                throw new InvalidOperationException($"The Customer with id:{command.Id} doesn't exists.");

            customer.UpdateCustomer(command.FirstName,
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
