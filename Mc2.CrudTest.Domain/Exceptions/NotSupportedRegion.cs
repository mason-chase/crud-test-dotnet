using Mc2.CrudTest.Shared.Abstraction.Exception;
namespace Mc2.CrudTest.Domain.Exceptions
{
    public class NotSupportedRegion:BaseException
    {
        public string Contintent { get;}
        public NotSupportedRegion(string contintent):base($"The region '{contintent}' is not supported.")
            => Contintent = contintent;
    }
}
