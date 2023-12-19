using Mc2.CrudTest.Application.Common.Models;
using MediatR;

namespace Mc2.CrudTest.Application.Queries;

public class GetCustomerByPhoneQuery : IRequest<Customer?>
{
    public string PhoneNumber { get; set; }
}