using Mc2.CrudTest.Application.Common.Models;
using MediatR;

namespace Mc2.CrudTest.Application.Queries;

public class GetCustomerByIdQuery : IRequest<Customer?>
{
    public long Id { get; set; }
}