using Application.Models;
using Mc2.CrudTest.Presentation.Shared;
using MediatR;

namespace Application.Features.Customers.Commands.Add
{
    public class AddCustomerCommand : IRequest<Result<int>>
    {
        public CreateCustomerDTO Customer { get; set; }
    }
}
