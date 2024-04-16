using Mc2.CrudTest.Domain.Models;
using MediatR;

namespace Mc2.CrudTest.Application.Features.Customer.Command.DeleteCustomer;

public class DeleteCustomerRequest : IRequest<CustomerModel>
{
    public string id { get; set; }
}