using MediatR;

namespace Mc2.CrudTest.Presentation.Shared.Commands;

public class DeleteCustomerCommand : IRequest
{
    public Guid CustomerId { get; set; }
}