using Mc2.CrudTest.Core.Domain.Customers.Commands;
using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Framework.Domain.ApplicationService;
using Mc2.CrudTest.Framework.Domain.Data;

namespace Mc2.CrudTest.Core.ApplicationService.Customers.CommandHandlers
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;

        }
        public void Handle(DeleteCustomerCommand command)
        {
            var customer = _customerRepository.Load(command.Id);

            if (customer is null)
                throw new InvalidOperationException($"The Customer with id:{command.Id} doesn't exists.");

            customer.DeleteCustomer();
            _unitOfWork.Commit();
        }
    }
}
