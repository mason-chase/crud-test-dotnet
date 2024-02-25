using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.AcceptanceTests.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public PhoneNumebrDao PhoneNumebr { get; set; }
        [Required]
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        [Required]
        public Status Status { get; set; }

        [Owned()]
        public class PhoneNumebrDao
        {
            public uint NationalNo { get; set; }
            public uint CountryCode { get; set; }
        }
    }
    public enum Status
    {
        Enable = 1,
        Disable,
        Deleted
    }

}
