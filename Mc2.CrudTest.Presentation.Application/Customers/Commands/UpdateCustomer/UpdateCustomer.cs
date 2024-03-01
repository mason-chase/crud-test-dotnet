

using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Common.Models;
using Mc2.CrudTest.Presentation.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Customers.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand(CustomerModel Customer) : IRequest<Result<CustomerModel>>;

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<CustomerModel>>
    {
        private readonly ICommandRepository _commandRepository;

        public UpdateCustomerCommandHandler(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<Result<CustomerModel>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<CustomerModel>();
            var customer = new Customer()
            {
                Id = request.Customer.Id,
                FirstName = request.Customer.FirstName,
                LastName = request.Customer.LastName,
                DateOfBirth = request.Customer.DateOfBirth,
                Email = request.Customer.Email,
                PhoneNumber = request.Customer.PhoneNumber,
                BankAccountNumber = request.Customer.BankAccountNumber
            };

            _commandRepository.UpdateAsync<Customer>(customer, cancellationToken);

            await _commandRepository.SaveChangesAsync();

            result.Data = request.Customer;

            return result;
        }
    }
}
