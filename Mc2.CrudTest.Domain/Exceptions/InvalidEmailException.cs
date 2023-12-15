using Mc2.CrudTest.Shared.Abstraction.Exception;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mc2.CrudTest.Tests")]
namespace Mc2.CrudTest.Domain.Exceptions
{
    internal class InvalidEmailException: BaseException
    {
        public InvalidEmailException(string email):base($"The E-mail '{email}' is not valid.")
        {
            
        }
    }
}
