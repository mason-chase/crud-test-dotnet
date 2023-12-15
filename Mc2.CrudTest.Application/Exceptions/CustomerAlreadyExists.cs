using Mc2.CrudTest.Shared.Abstraction.Exception;

namespace Mc2.CrudTest.Application.Exceptions
{
    public class CustomerAlreadyExists:BaseException
    {
        public CustomerAlreadyExists(string firstName, string sureName, DateOnly date)
            :base($"The Customer '{firstName}' '{sureName} born on '{date}' already exists;")
        {
            
        }
        public CustomerAlreadyExists(string email)
            : base($"The Customer with email '{email}' already exists;")
        {

        }
    }
}
