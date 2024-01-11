using Azure.Core;
using CQRS.NET;
using Domain.Abstractions;
using MediatR;

namespace Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerQueryHandler : IQueryHandler<GetCustomerByIdQuery, CustomerResponse>,
    IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }


    public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
        if (customer == null)
        {
            throw new Exception("das");

        }

        return new CustomerResponse
        {
            Firstname = customer.Firstname
        };
    }

    public async Task<CustomerResponse> HandleAsync(GetCustomerByIdQuery query)
    {
        var customer = await _customerRepository.GetByIdAsync(query.CustomerId);
        if (customer == null)
        {
            throw new Exception("das");

        }

        return new CustomerResponse
        {
            Firstname = customer.Firstname
        };
    }
}