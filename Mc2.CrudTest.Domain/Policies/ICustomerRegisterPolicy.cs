namespace Mc2.CrudTest.Domain.Policies
{
    public interface ICustomerRegisterPolicy
    {
        bool IsApplicable(PolicyData policyData);
    }
}
