using Common.Attributes;
using System.ComponentModel.DataAnnotations;
using static Common.Attributes.CustomizedValidationAttribute;

namespace Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(17)]
        [CustomizedValidation(ValidationType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [MaxLength(70)]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(20)]
        [CustomizedValidation(ValidationType.BankAccountNumber)]
        public string BankAccountNumber { get; set; }
    }
}
