using MediatR;

namespace Mc2.CrudTest.Application.Commands;

public class RemoveCustomerCommand:IRequest<bool>
{
    public long Id { get; set; }
}