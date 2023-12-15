namespace Mc2.CrudTest.Infrastructure.EF.Models
{
    internal class CustomerReadModel
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public FullNameReadModel FullName { get; set; }
        public DateOnly Birthday { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public long PhoneNumber { get; set; }
    }
}
