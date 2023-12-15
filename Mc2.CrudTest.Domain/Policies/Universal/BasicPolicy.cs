namespace Mc2.CrudTest.Domain.Policies.Universal
{
    internal sealed class BasicPolicy : ICustomerRegisterPolicy
    {
        public bool IsApplicable(PolicyData _)=> true;
    }
}
