using Domain.Entities;

namespace Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomersResponse
    {
        public List<Customer> Customers { get; set; }
    }
}
