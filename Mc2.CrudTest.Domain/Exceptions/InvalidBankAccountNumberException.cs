using Mc2.CrudTest.Shared.Abstraction.Exception;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mc2.CrudTest.Tests")]
namespace Mc2.CrudTest.Domain.Exceptions
{
    public class InvalidBankAccountNumberException: BaseException
    {
        public InvalidBankAccountNumberException(string bankAccountNumber) 
            : base($"The bank account number '{bankAccountNumber}' is invalid.")
        {
            
        }
    }
}
