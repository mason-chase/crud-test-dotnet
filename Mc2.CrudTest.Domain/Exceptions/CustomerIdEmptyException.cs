using Mc2.CrudTest.Shared.Abstraction.Exception;

namespace Mc2.CrudTest.Domain.Exceptions
{
    public class CustomerIdEmptyException:BaseException
    {
        public CustomerIdEmptyException() : base("The Customer Id Is Empty.")
        {

        }
    }
}
