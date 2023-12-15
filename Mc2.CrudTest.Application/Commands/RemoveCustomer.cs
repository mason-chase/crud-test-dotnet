using Mc2.CrudTest.Shared.Abstraction.Command;

namespace Mc2.CrudTest.Application.Commands
{
    public record RemoveCustomer(Guid Id):ICommand;
}
