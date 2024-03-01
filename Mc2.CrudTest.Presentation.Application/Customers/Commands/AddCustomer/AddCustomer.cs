using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Common.Models;
using Mc2.CrudTest.Presentation.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Customers.Commands.AddCustomer
{
    public record AddCustomerCommand(CustomerModel Customer) : IRequest<Result<CustomerModel>>;

    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Result<CustomerModel>>
    {
        private readonly ICommandRepository _commandRepository;

        public AddCustomerCommandHandler(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<Result<CustomerModel>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<CustomerModel>();

            var customer = new Customer()
            {
                FirstName = request.Customer.FirstName,
                LastName = request.Customer.LastName,
                DateOfBirth = request.Customer.DateOfBirth,
                Email = request.Customer.Email,
                PhoneNumber = request.Customer.PhoneNumber,
                BankAccountNumber = request.Customer.BankAccountNumber
            };

            var insertResult = await _commandRepository.InsertAsync<Customer>(customer);

            await _commandRepository.SaveChangesAsync();

            request.Customer.Id = insertResult.Id;

            result.Data = request.Customer;

            return result;
        }
    }
}
