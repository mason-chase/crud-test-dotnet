using System.Text.RegularExpressions;
using com.google.i18n.phonenumbers;

namespace Mc2.CrudTest.Application.Common.Helpers;

public static class ValidationHelper
{
    //Luhn Algorithm
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
    

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }
        
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }

    public static bool IsValidPhoneNumber(string number)
    {
        try
        {
            PhoneNumberUtil? phoneNumberUtil = PhoneNumberUtil.getInstance();
            Phonenumber.PhoneNumber? phoneNumber = phoneNumberUtil.parse(number, null);
            var isValid = phoneNumberUtil.isValidNumber(phoneNumber);
            return isValid;
        }
        catch (Exception e)
        {
            throw new Exception("The phone number is not valid!");
        }
    }
}