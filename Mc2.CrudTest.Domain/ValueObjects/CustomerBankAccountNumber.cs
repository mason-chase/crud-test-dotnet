using Mc2.CrudTest.Domain.Exceptions;
using System.Text;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record CustomerBankAccountNumber
    {
        public string Value { get; }
        public CustomerBankAccountNumber(string value)
        {
            if (!IsValid(value))
            {
                throw new InvalidBankAccountNumberException(value);
            }
            Value = value.Trim();
        }

        private bool IsValid(string bankAccount)
        {
            // From: https://www.codeproject.com/Tips/775696/IBAN-Validator
            bankAccount = bankAccount.ToUpper(); //IN ORDER TO COPE WITH THE REGEX BELOW
            if (String.IsNullOrEmpty(bankAccount))
                return false;
            else if (System.Text.RegularExpressions.Regex.IsMatch(bankAccount, "^[A-Z0-9]"))
            {
                bankAccount = bankAccount.Replace(" ", String.Empty);
                string bank =
                bankAccount.Substring(4, bankAccount.Length - 4) + bankAccount.Substring(0, 4);
                int asciiShift = 55;
                StringBuilder sb = new StringBuilder();
                foreach (char c in bank)
                {
                    int v;
                    if (Char.IsLetter(c)) v = c - asciiShift;
                    else v = int.Parse(c.ToString());
                    sb.Append(v);
                }
                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                return checksum == 1;
            }
            else
                return false;
        }

        public static implicit operator CustomerBankAccountNumber (string value) => new CustomerBankAccountNumber(value);
        public static implicit operator string (CustomerBankAccountNumber customerBankAccountNumber) => customerBankAccountNumber.Value;
    }
}
