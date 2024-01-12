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

        public static bool IsValidPhoneNumber(ulong phoneNumber)
        {
            // Add a "+" prefix to the phone number directly
            var phoneNumberStringify = $"+{phoneNumber}";

            if (string.IsNullOrWhiteSpace(phoneNumberStringify))
            {
                return false;
            }

            string regionCode = GetRegionCodeFromPhoneNumber(phoneNumberStringify);

            if (string.IsNullOrWhiteSpace(regionCode))
            {
                return false;
            }

            var phoneNumberUtil = PhoneNumberUtil.GetInstance();

            try
            {
                var parsedNumber = phoneNumberUtil.Parse(phoneNumberStringify, regionCode);

                return phoneNumberUtil.IsValidNumber(parsedNumber) &&
                       phoneNumberUtil.GetNumberType(parsedNumber) == PhoneNumberType.MOBILE;
            }
            catch (NumberParseException)
            {
                return false;
            }
        }



        public static bool IsValidBankAccountNumber(string bankAccountNumber)
        {
            string cleanedCardNumber = new string(bankAccountNumber.Where(char.IsDigit).ToArray());

            if (string.IsNullOrWhiteSpace(cleanedCardNumber))
            {
                return false;
            }

            int length = cleanedCardNumber.Length;
            if (length is < 13 or > 19)
            {
                return false;
            }

            int sum = 0;
            bool alternate = false;

            for (int i = length - 1; i >= 0; i--)
            {
                int digit = int.Parse(cleanedCardNumber[i].ToString());

                if (alternate)
                {
                    digit *= 2;

                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                alternate = !alternate;
            }
            return sum % 10 == 0;
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