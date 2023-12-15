using Mc2.CrudTest.Shared.Abstraction.Exception;

namespace Mc2.CrudTest.Domain.Exceptions
{
    public class CustomerNotUniqueException:BaseException
    {
        public CustomerNotUniqueException(string firstName, string sureName, DateOnly birthday )
            :base($"Customer with first name '{firstName}', sure name '{sureName}' and birthday '{birthday}' is not unique.")
        {
            
        }
    }
}
