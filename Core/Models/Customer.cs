﻿using Common.Attributes;
using static Common.Attributes.CustomizedValidationAttribute;

namespace Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [CustomizedValidation(ValidationType.MobileNumber)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}