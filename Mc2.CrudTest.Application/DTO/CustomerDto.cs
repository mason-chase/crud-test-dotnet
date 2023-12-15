namespace Mc2.CrudTest.Application.DTO
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public FullNameDto FullName { get; set; }
        public DateOnly Birthday { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
