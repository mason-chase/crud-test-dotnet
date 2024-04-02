using Application.Commom.Models;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Tools;
using Application.DTOs.Customer.Validations;
using Application.Entities.Customer.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Application.Entities.Customer.Handlers.Commands;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Result<bool>>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCustomerHandler(IMapper mapper, ICustomerRepository customerRepository
         , IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCustomerDtoValidator(_customerRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateCustomerDto);
        if (validationResult.IsValid == true)
        {
            var customer = await _customerRepository.Get(request.UpdateCustomerDto.Id);
            if (customer != null)
            {
                _mapper.Map(request.UpdateCustomerDto, customer);
                await _customerRepository.Update(customer);
                await _unitOfWork.Save();
                return Result<bool>.Success(true);
            }
            else
            {
                throw new NotFoundException("This customer not found.");
            }
        }
        else
        {
            throw new CustomeException(string.Join("، ", validationResult.Errors.Select(e => e.ErrorMessage).ToList()));
        }
    }
}
