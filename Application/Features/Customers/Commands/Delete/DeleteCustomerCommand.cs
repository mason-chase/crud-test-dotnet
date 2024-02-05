using Mc2.CrudTest.Presentation.Shared;
using MediatR;

namespace Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
