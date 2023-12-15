using Mc2.CrudTest.Shared.Abstraction.Command;

namespace Mc2.CrudTest.Application.Commands
{
    public record AddCustomer(Guid Id, FullNameWriteModel FullName, string Birthday, string email, string bankAccountNumber, string phoneNumber):ICommand;

    public record FullNameWriteModel(string FirstName,string LastName);
}
