using Mc2.CrudTest.Presentation.Shared.Domain;
using MediatR;


namespace Mc2.CrudTest.Presentation.Shared.Queries
{
    public record GetCustomerByIdQuery(int CustomerId) : IRequest<Result<CustomerModel>>;
}
