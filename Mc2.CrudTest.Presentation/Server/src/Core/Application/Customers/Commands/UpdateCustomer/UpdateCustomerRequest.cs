using System.ComponentModel.DataAnnotations;

namespace Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        public string Lastname { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public ulong PhoneNumber { get; set; } 
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string BankAccountNumber { get; set; } = string.Empty;
    }
}