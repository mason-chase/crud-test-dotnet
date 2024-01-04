using Mc2.CrudTest.Core.Domain.Customers.Commands;
using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Core.Domain.Customers.ValueObjects;
using Mc2.CrudTest.Framework.Domain.ApplicationService;

namespace Mc2.CrudTest.Core.ApplicationService.Customers.CommandHandlers
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Handle(DeleteCustomerCommand command)
        {
            var customer = _customerRepository.Load(command.Id);

            if (customer == null)
                throw new InvalidOperationException($"The Customer with id:{command.Id} doesn't exists.");

            customer.DeleteCustomer();
            _customerRepository.Save(customer);
            // unitOfWork.Commit();

        }
    }
}
