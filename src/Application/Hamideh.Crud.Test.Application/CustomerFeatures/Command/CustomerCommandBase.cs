using Microsoft.IdentityModel.Tokens;
using PhoneNumbers;
using System.Text.RegularExpressions;

namespace Hamideh.Crud.Test.Application.CustomerFeatures.Command
{
    public class CustomerCommandBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }



        public bool CheckPhoneNumberIsValid()
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var parsedPhoneNumber = phoneNumberUtil.Parse(PhoneNumber, null);
            return phoneNumberUtil.IsValidNumber(parsedPhoneNumber);

        }

        public bool CheckEmailIsValid()
        {
            return Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public bool CheckBankAccountNumberIsValid()
        {
            return !BankAccountNumber.IsNullOrEmpty();
        }

        public bool CheckLastNameIsEmpty()
        {
            return LastName.IsNullOrEmpty();
        }

        public bool CheckFirstNameIsEmpty()
        {
            return FirstName.IsNullOrEmpty();
        }
    }
}
