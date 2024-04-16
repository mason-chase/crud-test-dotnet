using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Entities.Customers
{
    public class Customer
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string? FirstName { get; set; }
        [StringLength(150, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string? LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [MobilePhoneNumber(ErrorMessage = "Invalid phone number.")]
        public ulong? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Bank account number must be a 10-digit number.")]
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
