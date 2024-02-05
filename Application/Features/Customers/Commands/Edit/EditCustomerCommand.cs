using Application.Models;
using Mc2.CrudTest.Presentation.Shared;
using MediatR;

namespace Application.Features.Customers.Commands.Edit
{
    public class EditCustomerCommand : IRequest<Result<int>>
    {

        public UpdateCustomerDTO Customer { get; set; }
    }
}
