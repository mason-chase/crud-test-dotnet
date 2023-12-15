using Mc2.CrudTest.Shared.Abstraction.Exception;

namespace Mc2.CrudTest.Domain.Exceptions
{
    public class InvalidBirthDayOnlyException:BaseException
    {
        public InvalidBirthDayOnlyException(DateOnly birthday) : base($"The Birthday '{birthday}' Is Invalid.")
        {
        }
        public InvalidBirthDayOnlyException(string birthday) : base($"The Birthday '{birthday}' Is Invalid.")
        {
        }
    }
}
