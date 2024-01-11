using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using Mc2.CrudTest.Application.Contract.Customers.Commands;
using Mc2.CrudTest.Application.Contract.Customers.Mappers;
using Mc2.CrudTest.Domain.Contract.Customers;
using Mc2.CrudTest.Infrastructure.Persistence;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.CommandHandlers;

internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result>
{
    private readonly IValidator<DeleteCustomerCommand> _validator;
    private readonly ICustomerWriteOnlyRepository _writeOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerCommandHandler(
        IValidator<DeleteCustomerCommand> validator,
        ICustomerWriteOnlyRepository repository,
        IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _writeOnlyRepository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
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

        customer.Delete();

        _writeOnlyRepository.Remove(customer);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
