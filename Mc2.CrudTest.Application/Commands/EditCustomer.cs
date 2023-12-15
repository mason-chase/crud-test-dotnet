using Mc2.CrudTest.Shared.Abstraction.Command;

namespace Mc2.CrudTest.Application.Commands
{
    public record EditCustomer(Guid Id, FullNameWriteModel FullName, string Birthday, string email, string bankAccountNumber, string phoneNumber) :ICommand;
}
