

using Mc2.CrudTest.Presentation.Domain.Common;

namespace Mc2.CrudTest.Presentation.Domain.Entities
{
    public class Customer : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BankAccountNumber { get; set; }
    }
}
