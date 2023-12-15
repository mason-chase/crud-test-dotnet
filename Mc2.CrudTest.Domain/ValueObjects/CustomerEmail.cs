using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record CustomerEmail
    {
        public string Value { get;}
        public CustomerEmail(string value)
        {
            if (!IsValid(value))
            {
                throw new InvalidEmailException(value);
            }
            Value = value.Trim();
        }

        private bool IsValid(string email)
        {
            //From this thread: https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith("."))
            {
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static implicit operator CustomerEmail(string value) => new CustomerEmail(value);
        public static implicit operator string(CustomerEmail customerEmail) => customerEmail.Value;
    }
}
