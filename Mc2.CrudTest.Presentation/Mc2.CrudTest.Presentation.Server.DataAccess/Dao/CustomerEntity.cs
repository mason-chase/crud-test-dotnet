using Mc2.CrudTest.Presentation.Server.DataAccess;
using Mc2.CrudTest.Presentation.Server.DataAccess.Dao;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Presentation.Server.Data
{
    [Table("Customers")]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(FirstName), nameof(LastName), nameof(BirthDate), IsUnique = true)]

    public class CustomerDao: IEntity, ISoftDelete
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public  int Id { get; set; }

        [Required]
        public  string FirstName { get; set; }
        [Required]
        public  string LastName { get; set; }
        public  DateTime BirthDate { get; set; }
        [Required]
        public PhoneNumebrDao PhoneNumebr { get; set; }
        [Required]
        public string Email { get; set; }
        public  string BankAccountNumber { get; set; }
        [Required]
        public Status Status { get; set; }

        [Owned()]
        public class PhoneNumebrDao
        {
            public uint NationalNo { get; set; }
            public uint CountryCode { get; set; }
        }
    }
}

    
