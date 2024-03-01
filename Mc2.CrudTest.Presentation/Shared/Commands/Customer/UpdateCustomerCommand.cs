using Mc2.CrudTest.Presentation.Shared.Domain;
using MediatR;

namespace Mc2.CrudTest.Presentation.Shared.Commands
{
    public record UpdateCustomerCommand(CustomerModel Customer) : IRequest<Result<CustomerModel>>;
}
