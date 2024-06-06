using Hamideh.Crud.Test.Domain;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Hamideh.Crud.Test.Application.CustomerFeatures.Command.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, AddCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public AddCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<AddCustomerCommandResponse> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            //TODO Its not best peractice of validations and exception handling
            string validationResult = ValidateAddCustomerQuery(request);
            if (!validationResult.IsNullOrEmpty()) throw new Exception(validationResult);

            await _customerRepository.AddCustomerAsync(new Domain.Entities.Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                BankAccountNumber = request.BankAccountNumber,
            });

            await _customerRepository.SaveChangesAsync(cancellationToken);

            return new AddCustomerCommandResponse()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                BankAccountNumber = request.BankAccountNumber,
            };

        }

        private static string ValidateAddCustomerQuery(AddCustomerCommand request)
        {
            if (request.CheckFirstNameIsEmpty()) return "Firstname can not be empty";
            if (request.CheckLastNameIsEmpty()) return "LastName can not be empty";
            if (!request.CheckBankAccountNumberIsValid()) return "BankAccountNumber is not valid";
            if (!request.CheckEmailIsValid()) return "Email is not valid";
            if (!request.CheckPhoneNumberIsValid()) return "PhoneNumber is not valid";

            return string.Empty;
        }


    }
}
