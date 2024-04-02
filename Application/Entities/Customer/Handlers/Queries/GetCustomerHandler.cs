using Application.Commom.Models;
using Application.Common.Interfaces.Repositories;
using Application.DTOs.Customer.Entities;
using Application.Entities.Customer.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Entities.Customer.Handlers.Queries;

public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Result<UpdateCustomerDto>>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    public GetCustomerHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }
    public async Task<Result<UpdateCustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.Get(request.Id);
        if (customer!=null)
        {
            var customerDto = _mapper.Map<UpdateCustomerDto>(customer);
            return Result<UpdateCustomerDto>.Success(customerDto);
        }
        else
        {
            return Result<UpdateCustomerDto>.Success(null, "This customer not found");
        }

    }
}
