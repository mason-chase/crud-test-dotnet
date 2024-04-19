using Application.Interfaces.Repositories;
using Mc2.CrudTest.Presentation.Shared;
using MediatR;

namespace Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result<int>>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<Result<int>> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(command.Id);
            if (customer != null)
            {
                await _customerRepository.DeleteAsync(customer);
                
                return await Result<int>.SuccessAsync("Customer Deleted");
            }
            else
            {
                return await Result<int>.FailAsync("Brand Not Found!");
            }

        }
    }
}
