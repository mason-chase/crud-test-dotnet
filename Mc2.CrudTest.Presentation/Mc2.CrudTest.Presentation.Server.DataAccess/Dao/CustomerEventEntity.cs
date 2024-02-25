using Mc2.CrudTest.Presentation.Server.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Mc2.CrudTest.Presentation.Server.DataAccess.Dao
{

    [Table("CustomersEvent")]
	public class CustomerEventEntity : IEntity, ISoftDelete
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[ForeignKey("Customers")]
		public long CustomerId { get; set; }
		[NotMapped]
		public CustomerDao Customer
		{
			get; set;
		}
		[Required]
		public string CustomerData
		{
			get; set;
		}

		[Required]
		public Status Status { get; set; }
		[Required]
		public CustomerEventType CustomerEventType { get; set; }
	}
}
