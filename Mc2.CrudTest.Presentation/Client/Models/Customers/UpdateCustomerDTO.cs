using Mc2.CrudTest.Presentation.Shared.SSOT;

namespace Mc2.CrudTest.Presentation.Client.Models.Customers
{
    public class UpdateCustomerDTO
    {

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// DateOfBirth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        public ulong PhoneNumber { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public CountrySSOT Country { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// BankAccountNumber
        /// </summary>
        public string BankAccountNumber { get; set; }
    }
}
