using CQRS.NET;
using MediatR;

namespace Application.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQuery : IRequest<CustomerResponse>
{
    public int CustomerId { get; }

    public GetCustomerByIdQuery(int customerId)
    {
        CustomerId = customerId;
    }
}