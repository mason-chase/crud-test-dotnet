using Application.Commom.Models;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Tools;
using Application.DTOs;
using Application.Entities.Customer.Requests.Commands;
using MediatR;

namespace Application.Entities.Customer.Handlers.Commands;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Result<bool>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteCustomerHandler(ICustomerRepository customerRepository
        , IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var validator = new BaseDtoValidator();
        var validationResult = await validator.ValidateAsync(new BaseDto(request.Id));
        if (validationResult.IsValid == true)
        {
            var customer = await _customerRepository.Get(request.Id);
            if (customer != null)
            {
                await _customerRepository.Delete(customer);
                await _unitOfWork.Save();
                return Result<bool>.Success(true);
            }
            else
            {
                throw new NotFoundException("This customer not found");
            }
        }
        else
        {
            throw new CustomeException(string.Join("، ", validationResult.Errors.Select(e => e.ErrorMessage).ToList()));
        }

    }
}
