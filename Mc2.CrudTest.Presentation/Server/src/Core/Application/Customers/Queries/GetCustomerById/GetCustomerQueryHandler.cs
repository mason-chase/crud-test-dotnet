using AutoMapper;
using Azure.Core;
using CQRS.NET;
using Domain.Abstractions;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerQueryHandler : IQueryHandler<GetCustomerByIdQuery, CustomerResponse>,
    IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public GetCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }


    public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
        if (customer == null)
        {
            throw new Exception("custommer didnt find");

        }

        return _mapper.Map<CustomerResponse>(customer);
    }

    public async Task<CustomerResponse> HandleAsync(GetCustomerByIdQuery query)
    {
        var customer = await _customerRepository.GetByIdAsync(query.CustomerId);
        if (customer == null)
        {
            throw new Exception("custommer didnt find");

        }

        return _mapper.Map<CustomerResponse>(customer);
    }
}