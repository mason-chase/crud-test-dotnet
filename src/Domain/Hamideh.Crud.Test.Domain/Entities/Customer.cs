using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamideh.Crud.Test.Domain.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(22)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string BankAccountNumber { get; set; }

    }
}
