using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using Mc2.CrudTest.Application.Contract.Customers.Commands;
using Mc2.CrudTest.Domain.Contract.Customers;
using Mc2.CrudTest.Infrastructure.Persistence;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.CommandHandlers;

internal class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result>
{
    private readonly IValidator<UpdateCustomerCommand> _validator;
    private readonly ICustomerWriteOnlyRepository _writeOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(
        IValidator<UpdateCustomerCommand> validator,
        ICustomerWriteOnlyRepository repository,
        IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _writeOnlyRepository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.Invalid(validationResult.AsErrors());
        }

        var customer = await _writeOnlyRepository.GetByIdAsync(command.Id);

        if (customer == null)
        {
            return Result.Error("Customer does not exist.");
        }

        var isExistsEmail = await _writeOnlyRepository.ExistsByEmailAsync(command.Email, command.Id);

        if (isExistsEmail)
        {
            return Result.Error("The email address already exists.");
        }

        var isExistsPerson = await _writeOnlyRepository.ExistsByFullnameAndBirthdateAsync(command.Firstname, command.Lastname, command.DateOfBirth, command.Id);

        if (isExistsPerson)
        {
            return Result.Error($"There is already a Person with the given first name, last name and phone number.");
        }

        customer.ChangeEmail(command.Email);

        _writeOnlyRepository.Update(customer);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
