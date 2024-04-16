using Mc2.CrudTest.Domain.Models;
using MediatR;


namespace Mc2.CrudTest.Application.Features.Customer.Query.GetAllCustomers;

public class GetAllCustomersRequest : IRequest<List<CustomerModel>>
{
    public int Skip { get; set; }
    public int Limit { get; set; }
}