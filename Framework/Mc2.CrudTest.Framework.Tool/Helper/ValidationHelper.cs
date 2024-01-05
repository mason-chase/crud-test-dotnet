using PhoneNumbers;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Framework.Tool.Helper
{
    public class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(email))
                return false;

            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            try
            {
                var phoneUtil = PhoneNumberUtil.GetInstance();

                var numberProto = phoneUtil.Parse(phoneNumber, "CA");
                if (!phoneUtil.IsValidNumber(numberProto))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
