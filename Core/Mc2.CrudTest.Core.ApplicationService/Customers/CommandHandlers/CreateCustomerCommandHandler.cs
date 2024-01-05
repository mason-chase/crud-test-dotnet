using Mc2.CrudTest.Core.Domain.Customers.Commands;
using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Mc2.CrudTest.Core.Domain.Customers.ValueObjects;
using Mc2.CrudTest.Framework.Domain.ApplicationService;
using Mc2.CrudTest.Framework.Domain.Data;

namespace Mc2.CrudTest.Core.ApplicationService.Customers.CommandHandlers
{
    public class CreateCustomerCommandHandler :ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;

        }
        public void Handle(CreateCustomerCommand command)
        {
            if (_customerRepository.FindByEmail(command.Email) != null)
                throw new InvalidOperationException($"The Customer with email:{command.Email} already exists.");

            var customer = new Customer(Guid.NewGuid(), 
                                        command.FirstName,
                                        command.LastName,
                                        Email.FromString(command.Email),
                                        PhoneNumber.FromString(command.PhoneNumber),
                                        BankAccountNumber.FromString(command.BankAccountNumber),
                                        command.DateOfBirth);
            _customerRepository.Add(customer);
            _unitOfWork.Commit();
  
        }
    }
}
