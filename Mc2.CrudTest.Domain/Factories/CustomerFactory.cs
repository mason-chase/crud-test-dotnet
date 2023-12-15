using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Factories
{
    public sealed class CustomerFactory : ICustomerFactory
    {
        public Customer Create(CustomerId id, CustomerFullName fullName, CustomerBirthday birthday, CustomerEmail email,
            CustomerBankAccountNumber bankAccountNumber, CustomerPhoneNumber phoneNumber)
            =>new Customer(id,fullName,birthday,email,bankAccountNumber,phoneNumber);
    }
}
