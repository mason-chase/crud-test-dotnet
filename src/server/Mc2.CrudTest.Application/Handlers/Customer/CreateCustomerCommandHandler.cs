using Mc2.CrudTest.Application.Commands.Customer;
using Mc2.CrudTest.Common;
using Mc2.CrudTest.Contracts;
using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepo _customerRepo;
    private readonly ILoggerAdapter<CreateCustomerCommandHandler> _logger;

    public CreateCustomerCommandHandler(ICustomerRepo customerRepo, ILoggerAdapter<CreateCustomerCommandHandler> logger)
    {
        _customerRepo = customerRepo;
        _logger = logger;
    }

    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (ValidationHelper.IsValidCreditCardNumber(request.BankAccountNumber) &&
                ValidationHelper.IsValidEmail(request.Email) &&
                ValidationHelper.IsValidPhoneNumber(request.PhoneNumber.ToString()))
            {
                await _customerRepo.AddAsync(new Domain.Entities.Customer
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    BankAccountNumber = request.BankAccountNumber
                });
            }
            else
            {
                _logger.LogInformation("Invalid Parameters --> Email | PhoneNumber | BankAccountNumber");
                throw new Exception("Invalid Parameters");
            }
        }
        catch (Exception e)
        {
            _logger.LogError($"Create Customer Has Error --> {e.Message}");
            throw;
        }

    }
}