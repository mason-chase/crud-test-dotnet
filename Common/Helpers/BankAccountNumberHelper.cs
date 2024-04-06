namespace Common.Helpers
{
    public static class BankAccountNumberHelper
    {
        const string BANKACCOUNTNUMBERPATTERN = @"((\\d{4})-){3}\\d{4}";
        public static bool IsValidBankAccountNumber(string bankAccountNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(bankAccountNumber, BANKACCOUNTNUMBERPATTERN);
        }
    }
}
