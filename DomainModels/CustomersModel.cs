using webapi.Models;

namespace webapi.DomainModels
{
    /// <summary>
    /// Business or Logics of the domain is implemented and checked in this class
    /// </summary>
    public class CustomerModel
    {
        public bool CheckPhoneNumber(string PhoneNumber)
        {
            var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
            var usPhoneNumber = phoneNumberUtil.Parse(PhoneNumber, "");
            return phoneNumberUtil.IsValidNumber(usPhoneNumber);
        }

        public bool CheckEmail(string Email)
        {
            var trimmedEmail = Email.Trim();
            if (trimmedEmail.EndsWith("."))
                return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckAccountNumber(string AccountNumber)
        {
            if (AccountNumber.Length == 20)         //:TODO - not sure if it should be 20 or less, needs to be checked!
                return true;
            else
                return false;
        }

        public bool CheckNameBirthDateUniqueness(Customer newCustomer, Customer oldCustomer)
        {
            if (newCustomer.Firstname == oldCustomer.Firstname &&
                newCustomer.Lastname == oldCustomer.Lastname &&
                newCustomer.DateOfBirth == oldCustomer.DateOfBirth)
                return false;
            else
                return true;
        }

        public bool CheckEmailUniqueness(Customer newCustomer, Customer oldCustomer)
        {
            if (newCustomer.Email == oldCustomer.Email)
                return false;
            else
                return true;
        }
    }
}