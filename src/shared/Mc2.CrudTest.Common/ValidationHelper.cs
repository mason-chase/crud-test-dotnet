using System.Net.Mail;
using PhoneNumbers;


namespace Mc2.CrudTest.Common;

public static class ValidationHelper
{
    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        try
        {
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber number = phoneNumberUtil.Parse(phoneNumber, null);
            return phoneNumberUtil.IsValidNumber(number);
        }
        catch (NumberParseException)
        {
            return false;
        }
    }

    public static bool IsValidEmail(string email)
    {
        try
        {
            var mailAddress = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    // Example of credit card number validation using a simple Luhn algorithm
    public static bool IsValidCreditCardNumber(string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber))
            return false;

        cardNumber = cardNumber.Replace(" ", "");

        int[] digits = cardNumber.Reverse()
            .Select(c => Convert.ToInt32(c.ToString()))
            .ToArray();

        int sum = 0;
        bool doubleUp = false;

        foreach (int digit in digits)
        {
            int doubled = digit * (doubleUp ? 2 : 1);
            sum += doubled > 9 ? doubled - 9 : doubled;
            doubleUp = !doubleUp;
        }

        return sum % 10 == 0;
    }
}
