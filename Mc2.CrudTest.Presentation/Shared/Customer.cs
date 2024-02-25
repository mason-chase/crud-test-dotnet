
using Mc2.CrudTest.Presentation.Server.Data;


namespace Mc2.CrudTest.Presentation.Shared
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public PhoneNumber PhoneNum { get; set; }

        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public bool ShowDetails { get; set; }

        public class PhoneNumber
        {
            public uint NationalNo { get; set; }
            public uint CountryCode { get; set; }
        }


		public void LoadFromModel(CustomerDao dao)
        {
            Id = dao.Id;
            FirstName = dao.FirstName;
            LastName = dao.LastName;
            BirthDate = dao.BirthDate;
            PhoneNum = new PhoneNumber
            {
                CountryCode = dao.PhoneNumebr.CountryCode,
                NationalNo = dao.PhoneNumebr.NationalNo
            };
            Email = dao.Email; //!= null ? new MailAddress(dao.Email) : null;
            BankAccountNumber = dao.BankAccountNumber;
        }

        public object ExtractModelObject()
        {
            return new CustomerDao
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate.Date,
                PhoneNumebr = new CustomerDao.PhoneNumebrDao { CountryCode = PhoneNum .CountryCode, NationalNo = PhoneNum.NationalNo},
                Email = Email,//!= null?  Email.ToString():"",
                BankAccountNumber = BankAccountNumber
            };
        }

    }
}