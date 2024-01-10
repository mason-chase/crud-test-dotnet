using Ardalis.Result;
using Mc2.CrudTest.Application.Contract.Customers.Responses;
using MediatR;

namespace Mc2.CrudTest.Application.Contract.Customers.Queries;

public class GetCustomerByIdQuery : IRequest<Result<GetCustomerByIdResponse>>
{
    public Guid Id { get; init; }
}
