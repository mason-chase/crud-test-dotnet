using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Shared.Commands;
using Mc2.CrudTest.Presentation.Shared.Domain;
using Mc2.CrudTest.Presentation.Shared.Interfaces.Data;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.CommandHandlers
{
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
