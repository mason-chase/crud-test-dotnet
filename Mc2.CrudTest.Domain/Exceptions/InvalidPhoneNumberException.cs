using Mc2.CrudTest.Shared.Abstraction.Exception;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mc2.CrudTest.Tests")]
namespace Mc2.CrudTest.Domain.Exceptions
{
    public class InvalidPhoneNumberException: BaseException
    {
        public InvalidPhoneNumberException(string phoneNumber):base($"Then phone number '{phoneNumber}' is not valid")
        {
            
        }
    }
}
