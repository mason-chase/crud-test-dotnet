using Mc2.CrudTest.Domain.ValueObjects;
using Shouldly;
using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Tests.Domain
{
    public class CustomerTest
    {
        [Fact]
        public void Test_Invalid_Email1()
        {
            //ARRANGE
            string email = "123466";
            //ACT
            var exception = Record.Exception(() => new CustomerEmail(email));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidEmailException>();
        }

        [Fact]
        public void Test_Invalid_Bank_Account1()
        {
            //ARRANGE
            string bankAccount = "123466321456";

            //ACT
            var exception = Record.Exception(() => new CustomerBankAccountNumber(bankAccount));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidBankAccountNumberException>();
        }

        [Fact]
        public void Test_Valid_Email1()
        {
            //ARRANGE
            string email = "shamsaii@gmail.com";
            //ACT
            var exception = Record.Exception(() => new CustomerEmail(email));

            //ASSERT
            exception.ShouldBeNull();
        }

        [Fact]
        public void Test_Valid_Bank_Account1()
        {
            //ARRANGE
            string bankAccount = "DE08700901001234567890";

            //ACT
            var exception = Record.Exception(() => new CustomerBankAccountNumber(bankAccount));

            //ASSERT
            exception.ShouldBeNull();
        }

        [Fact]
        public void Test_Invalid_PhoneN_Number1()
        {
            //ARRANGE
            string phoneNumber = "abc123";

            //ACT
            var exception = Record.Exception(() => new CustomerPhoneNumber(phoneNumber));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidPhoneNumberException>();
        }

        [Fact]
        public void Test_Valid_Phone_Number()
        {
            //ARRANGE
            string phoneNumber = "09135742566";

            //ACT
            var exception = Record.Exception(() => new CustomerPhoneNumber(phoneNumber));

            //ASSERT
            exception.ShouldBeNull();
        }
    }
}
