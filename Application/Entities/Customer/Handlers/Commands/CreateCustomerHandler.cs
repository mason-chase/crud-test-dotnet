using Application.Commom.Models;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Tools;
using Application.DTOs.Customer.Validations;
using Application.Entities.Customer.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Entities.Customer.Handlers.Commands;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Result<int>>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerHandler(IMapper mapper, ICustomerRepository customerRepository
        , IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerDtoValidator(_customerRepository);
        var validationResult = await validator.ValidateAsync(request.CreateCustomerDto);
        if (validationResult.IsValid == true)
        {
            var customer = _mapper.Map<Domain.Entities.Customer>(request.CreateCustomerDto);
            customer = await _customerRepository.Add(customer);
            await _unitOfWork.Save();
            return Result<int>.Success(customer.Id);
        }
        else
        {
            throw new CustomeException(string.Join("، ", validationResult.Errors.Select(e => e.ErrorMessage).ToList()));
        }

    }
}
