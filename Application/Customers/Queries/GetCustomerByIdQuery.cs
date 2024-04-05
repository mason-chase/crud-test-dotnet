using Core.Models;
using MediatR;

namespace Application.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}