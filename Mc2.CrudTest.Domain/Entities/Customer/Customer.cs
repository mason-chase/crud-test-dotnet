using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Entities.Customer
{
    public class Customer
    {
        [Key]
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MobilePhoneNumber]
        public ulong? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
        [RegularExpression(@"((\\d{4})-){3}\\d{4}", ErrorMessage = "Invalid Bank Account Number")]
        public string? BankAccountNumber { get; set; }

    }

    public class MobilePhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phoneNumber = value as string;

            if (string.IsNullOrEmpty(phoneNumber))
            {
                return ValidationResult.Success; // Allow null or empty phone numbers
            }

            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var parsedNumber = phoneNumberUtil.Parse(phoneNumber, null);

            if (!phoneNumberUtil.IsValidNumber(parsedNumber) || phoneNumberUtil.GetNumberType(parsedNumber) != PhoneNumberType.MOBILE)
            {
                return new ValidationResult("Invalid mobile phone number.");
            }

            return ValidationResult.Success;
        }
    }

}
