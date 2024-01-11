using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using Mc2.CrudTest.Application.Contract.Customers.Commands;
using Mc2.CrudTest.Application.Contract.Customers.Mappers;
using Mc2.CrudTest.Application.Contract.Customers.Responses;
using Mc2.CrudTest.Domain.Contract.Customers;
using Mc2.CrudTest.Infrastructure.Persistence;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.CommandHandlers;

internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<CreatedCustomerResponse>>
{
    private readonly IValidator<CreateCustomerCommand> _validator;
    private readonly ICustomerWriteOnlyRepository _writeOnlyRepository;
    private readonly ICreateCustomerCommandMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(
        IValidator<CreateCustomerCommand> validator,
        ICustomerWriteOnlyRepository repository,
        ICreateCustomerCommandMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _writeOnlyRepository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CreatedCustomerResponse>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result<CreatedCustomerResponse>.Invalid(validationResult.AsErrors());
        }

        var isExistsEmail = await _writeOnlyRepository.ExistsByEmailAsync(command.Email);

        if (isExistsEmail)
        {
            return Result<CreatedCustomerResponse>.Error("The email address already exists.");
        }

        var isExistsPerson = await _writeOnlyRepository.ExistsByFullnameAndBirthdateAsync(command.Firstname, command.Lastname, command.DateOfBirth);

        if (isExistsPerson)
        {
            return Result<CreatedCustomerResponse>.Error($"There is already a Person with the given first name, last name and phone number.");
        }

        var customer = _mapper.Map(command);

        _writeOnlyRepository.Add(customer);

        await _unitOfWork.SaveChangesAsync();

        return Result<CreatedCustomerResponse>.Success(_mapper.Map(customer));
    }
}
