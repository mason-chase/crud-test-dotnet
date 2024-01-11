using Application.Customers.Queries.GetCustomerById;
using MediatR;

namespace Application.Customers.Queries.GetAllCustomer
{
    public record GetAllCustomersQuery : IRequest<List<CustomerResponse>>;


}