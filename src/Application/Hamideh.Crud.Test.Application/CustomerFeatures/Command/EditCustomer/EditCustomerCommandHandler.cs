using Hamideh.Crud.Test.Domain;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Hamideh.Crud.Test.Application.CustomerFeatures.Command.AddCustomer
{
    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, EditCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public EditCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<EditCustomerCommandResponse> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            //TODO Its not best peractice of validations and exception handling
            string validationResult = ValidateAddCustomerQuery(request);
            if (!validationResult.IsNullOrEmpty()) throw new Exception(validationResult);

            var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);
            if (customer is null) throw new Exception("Customer not found");

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.DateOfBirth = request.DateOfBirth;

            _customerRepository.EditCustomer(customer);

            await _customerRepository.SaveChangesAsync(cancellationToken);

            return new EditCustomerCommandResponse();

        }

        private static string ValidateAddCustomerQuery(EditCustomerCommand request)
        {
            if (request.CheckFirstNameIsEmpty()) return "Firstname can not be empty";
            if (request.CheckLastNameIsEmpty()) return "LastName can not be empty";

            return string.Empty;
        }


    }
}
