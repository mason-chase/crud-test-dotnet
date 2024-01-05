using Mc2.CrudTest.Core.Domain.Customers.Commands;
using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Core.Domain.Customers.ValueObjects;
using Mc2.CrudTest.Framework.Domain.ApplicationService;
using Mc2.CrudTest.Framework.Domain.Data;

namespace Mc2.CrudTest.Core.ApplicationService.Customers.CommandHandlers
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;

        }
        public void Handle(UpdateCustomerCommand command)
        {
            var customer = _customerRepository.Load(command.Id);

            if (customer == null)
                throw new InvalidOperationException($"The Customer with id:{command.Id} doesn't exists.");

            var customerInfo = _customerRepository.FindByEmail(command.Email);
            if (customerInfo != null && customerInfo.Id != command.Id)
                throw new InvalidOperationException($"The Customer with email:{command.Email} already exists.");

            customer.UpdateCustomer(command.FirstName,
                                    command.LastName, 
                                    Email.FromString(command.Email), 
                                    PhoneNumber.FromString(command.PhoneNumber), 
                                    BankAccountNumber.FromString(command.BankAccountNumber), 
                                    command.DateOfBirth);
            _unitOfWork.Commit();
        }
    }
}
