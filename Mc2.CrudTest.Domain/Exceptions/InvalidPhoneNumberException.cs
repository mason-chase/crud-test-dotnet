using Mc2.CrudTest.Shared.Abstraction.Exception;

namespace Mc2.CrudTest.Domain.Exceptions
{
    public class InvalidPhoneNumberException: BaseException
    {
        public InvalidPhoneNumberException(string phoneNumber):base($"Then phone number '{phoneNumber}' is not valid")
        {
            
        }
    }
}
