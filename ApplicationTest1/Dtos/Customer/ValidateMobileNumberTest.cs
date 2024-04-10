using PhoneNumbers;


namespace Application.Test.Dtos.Customer
{
    [TestFixture]
    public class ValidateMobileNumberTest
    {
        [Test]
        [TestCase(ExpectedResult = true)]

        public bool CheckMobileNumber_IsValid_ReturnTrue()
        {
            string correctMobileNumber = "+989121234567";
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

            PhoneNumber phoneNumber = phoneUtil.Parse(correctMobileNumber, "IR");
            return phoneUtil.IsValidNumber(phoneNumber);


        }

        [Test]
        [TestCase(ExpectedResult = false)]
        public bool CheckMobileNumber_IsValid_ReturnFalse()
        {
            String wrongMobileNumber = "+982188776655";
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

            PhoneNumber phoneNumber = phoneUtil.Parse(wrongMobileNumber, "IR");
            PhoneNumberType phoneNumberType= phoneUtil.GetNumberType(phoneNumber);
            if (phoneNumberType == PhoneNumberType.MOBILE)
                return phoneUtil.IsValidNumber(phoneNumber);
            else return false;



        }
    }
}
