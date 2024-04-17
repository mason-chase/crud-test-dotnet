using Mc2.CrudTest.Presentation.Application.Common.Validation;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Presentation.Application.Common.Models
{
    public class CustomerModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [PhoneNumberValidate]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(30)]
        public string BankAccountNumber { get; set; }
    }
}
