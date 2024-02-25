using Mc2.CrudTest.Presentation.Server.DataAccess;
using Mc2.CrudTest.Presentation.Server.DataAccess.Dao;


namespace Mc2.CrudTest.Presentation.Shared
{
	public class CustomerEvent
    {
		public Guid Id { get; set; }

		//[ForeignKey("Customers")]
		public long CustomerId { get; set; }


		public string CustomerData
		{
			get; set;
		}

		public Status Status { get; set; }

		public CustomerEventType CustomerEventType { get; set; }
            

        public void LoadFromModel(CustomerEventEntity dao)
        {
            Id = dao.Id;
			CustomerData = dao.CustomerData;
			CustomerEventType = dao.CustomerEventType;
			Status = dao.Status;
			CustomerId = dao.CustomerId;

		}

        public object ExtractModelObject()
        {
            return new CustomerEventEntity
			{
                Id = Id,
				CustomerData = CustomerData,
				CustomerEventType = CustomerEventType,
				Status= Status,
				CustomerId= CustomerId

			};
        }

    }
}