using Core.Models;
using MediatR;

namespace Application.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<List<Customer>>
    {
    }
}