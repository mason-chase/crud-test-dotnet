namespace Mc2.CrudTest.Shared.Abstraction.Exception
{
    public abstract class BaseException : System.Exception
    {
        protected BaseException(string message) : base(message)
        {

        }
    }
}
