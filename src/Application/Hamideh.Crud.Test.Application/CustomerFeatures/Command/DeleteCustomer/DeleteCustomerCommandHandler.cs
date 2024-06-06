using Hamideh.Crud.Test.Domain;
using MediatR;

namespace Hamideh.Crud.Test.Application.CustomerFeatures.Command.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            //TODO Its not best peractice of  exception handling
            var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);
            if (customer is null) throw new Exception("Customer not found");

            _customerRepository.DeleteCustomer(customer);

            await _customerRepository.SaveChangesAsync(cancellationToken);

            return new DeleteCustomerCommandResponse();

        }



    }
}
