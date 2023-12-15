using Mc2.CrudTest.Shared.Abstraction.Exception;

namespace Mc2.CrudTest.Domain.Exceptions
{
    public class InvalidLastNameException: BaseException
    {
        public InvalidLastNameException(string sureName) : base($"Customer sure name '{sureName}' is not valid.")
        {
            
        }
    }
}
