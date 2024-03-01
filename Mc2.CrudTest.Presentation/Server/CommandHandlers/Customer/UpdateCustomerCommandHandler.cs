using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Shared.Commands;
using Mc2.CrudTest.Presentation.Shared.Domain;
using Mc2.CrudTest.Presentation.Shared.Interfaces.Data;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.CommandHandlers
{
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
