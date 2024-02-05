using Mc2.CrudTest.Presentation.Shared;
using MediatR;

namespace Application.Features.Customers.Queries.GetById
{
    public class GetCustomerByIdQuery : IRequest<Result<GetCustomerByIdResponse>>
    {
        public int Id { get; set; }
    }
}
