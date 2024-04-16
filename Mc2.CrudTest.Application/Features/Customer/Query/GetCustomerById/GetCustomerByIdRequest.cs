using Mc2.CrudTest.Domain.Models;
using MediatR;

namespace Mc2.CrudTest.Application.Features.Customer.Query.GetCustomerById;

public class GetCustomerByIdRequest : IRequest<CustomerModel>
{
    public string id { get; set; }
}