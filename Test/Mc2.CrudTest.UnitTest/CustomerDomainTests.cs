using Mc2.CrudTest.Core.Domain.Customers.ValueObjects;

namespace Mc2.CrudTest.UnitTest
{
    public class CrudCustomerServiceTests
    {
        [Fact]
        public void Email_ShouldRaiseException_IfEmailIsInValid()
        {
            Assert.Throws<ArgumentException>(() => Email.FromString("invalidEmail"));
        }

        [Fact]
        public void Email_ShouldRaiseException_IfEmailIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => Email.FromString(string.Empty));
        }

        [Fact]
        public void Email_ShouldCreateEmailObject_IfEmailIsValid()
        {
            var emailAddress = "saharamoorezaie@gmail.com";
            var email = Email.FromString(emailAddress);
            Assert.Equal(email.Value, emailAddress);
        }
    }
}