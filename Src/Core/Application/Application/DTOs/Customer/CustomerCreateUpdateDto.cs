using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Customer
{
    public class CustomerCreateUpdateDto
    {
        [Required(ErrorMessage = "First name is required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth  name is required!")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number is required!")]
        public ulong PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Email is not correct!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bank account number  is required!")]
        public string BankAccountNumber { get; set; }
    }
}