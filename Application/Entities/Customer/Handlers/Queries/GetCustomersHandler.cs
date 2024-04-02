using Application.Commom.Models;
using Application.Common.Interfaces.Repositories;
using Application.DTOs.Customer.Entities;
using Application.Entities.Customer.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Entities.Customer.Handlers.Queries;

public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, Result<List<CustomerListDto>>>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    public GetCustomersHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }
    public async Task<Result<List<CustomerListDto>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customerList = await _customerRepository.Search(request.CustomerSearchDto);
        if (customerList.Any())
        {
            var customerListDto = _mapper.Map<List<CustomerListDto>>(customerList);
            return Result<List<CustomerListDto>>.Success(customerListDto);
        }
        else
        {
            return Result<List<CustomerListDto>>.Success(null, "There is no customer.");
        }

    }
}
