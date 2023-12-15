using Mc2.CrudTest.Shared.Abstraction.Exception;

namespace Mc2.CrudTest.Domain.Exceptions
{
    internal class InvalidEmailException: BaseException
    {
        public InvalidEmailException(string email):base($"The E-mail '{email}' is not valid.")
        {
            
        }
    }
}
