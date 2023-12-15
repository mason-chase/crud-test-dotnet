using Mc2.CrudTest.Shared.Abstraction.Exception;
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
