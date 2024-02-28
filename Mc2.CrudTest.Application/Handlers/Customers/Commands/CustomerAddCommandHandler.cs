using FluentValidation;
using Mc2.CrudTest.Application.Options;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.SharedKernel.Domain.Abstraction;
using MediatR;
using Microsoft.Extensions.Options;

namespace Mc2.CrudTest.Application.Handlers.Customers.Commands;

public class CustomerAddCommandHandler : IRequestHandler<CustomerAddCommand, ServiceCommandResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CustomerAddCommand> _customerValidator;
    private readonly ApplicationErrors _applicationErrors;

    public CustomerAddCommandHandler(IUnitOfWork unitOfWork,
        IValidator<CustomerAddCommand> customerValidator,
        IOptions<ApplicationErrors> applicationErrors)
    {
        _unitOfWork = unitOfWork;
        _customerValidator = customerValidator;
        _applicationErrors = applicationErrors.Value;
    }

    public async Task<ServiceCommandResult> Handle(CustomerAddCommand command, CancellationToken cancellationToken)
    {
        var validationResult = _customerValidator.Validate(command);

        if (validationResult.IsValid)
        {
            var customer = Customer.New(
                new IdGen.IdGenerator(0).CreateId(),
                command.FirstName,
                command.LastName,
                command.DateOfBirth,
                command.PhoneNumber,
                command.Email,
                command.BankAccount);

            var customerExistBefore = await _unitOfWork.CustomerRepository.GetAsync
                (c => c.FirstName == customer.FirstName && c.LastName == customer.LastName &&
                c.DateOfBirth == customer.DateOfBirth, cancellationToken);

            if (customerExistBefore != null)
            {
                return new ServiceCommandResult(CommandErrorType.Validation, _applicationErrors.DuplicatedCustomer);
            }


            var customerWithSameEmailExist = await _unitOfWork.CustomerRepository.GetAsync
                (c => c.Email == customer.Email, cancellationToken);

            if (customerWithSameEmailExist != null)
            {
                return new ServiceCommandResult(CommandErrorType.Validation, _applicationErrors.ThisEmailUsedBefore);
            }

            await _unitOfWork.CustomerRepository.AddAsync(customer, cancellationToken);

            var saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return saveResult > 0 ? new ServiceCommandResult(customer.Id.ToString()) : new ServiceCommandResult(CommandErrorType.General, _applicationErrors.NoRowsWereAffected);


        }
        else
        {
            return new ServiceCommandResult(CommandErrorType.Validation, validationResult.Errors.Select(p => p.ErrorMessage).ToArray());
        }

    }
}
