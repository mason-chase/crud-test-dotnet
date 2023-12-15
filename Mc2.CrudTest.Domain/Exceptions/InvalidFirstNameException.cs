using Mc2.CrudTest.Shared.Abstraction.Exception;

namespace Mc2.CrudTest.Domain.Exceptions
{
    public class InvalidFirstNameException: BaseException
    {
        public InvalidFirstNameException(string firstName):base($"The first name '{firstName}' is not valid.")
        {
            
        }
    }
}
