using PhoneNumbers;
using System.Text.RegularExpressions;

namespace Application.Behaviours
{
    public abstract class CustomerValidator
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$";
            Regex regex = new Regex(emailPattern);

            return regex.IsMatch(email);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string regionCode = GetRegionCodeFromPhoneNumber(phoneNumber);

            if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(regionCode))
            {
                return false;
            }

            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var parsedNumber = phoneNumberUtil.Parse(phoneNumber, regionCode);
                return phoneNumberUtil.IsValidNumber(parsedNumber) &&
                       phoneNumberUtil.GetNumberType(parsedNumber) == PhoneNumberType.MOBILE;
            }
            catch (NumberParseException)
            {
                return false;
            }
        }

        private static string GetRegionCodeFromPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length >= 3)
            {
                return phoneNumber.Substring(0, 3);
            }
            return "DefaultRegionCode";
        }

    }
}