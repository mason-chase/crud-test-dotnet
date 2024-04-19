using Mc2.CrudTest.Presentation.Shared;
using MediatR;

namespace Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomersQuery : IRequest<Result<GetAllCustomersResponse>>
    {
    }
}
