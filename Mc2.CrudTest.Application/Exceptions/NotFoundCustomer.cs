using Mc2.CrudTest.Shared.Abstraction.Exception;

namespace Mc2.CrudTest.Application.Exceptions
{
    public class NotFoundCustomer:BaseException
    {
        public NotFoundCustomer(Guid guid):base($"No Customer With The Id '{guid}' Was Found.")
        {
            
        }
    }
}
