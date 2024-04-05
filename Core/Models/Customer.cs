namespace Core.Models
{
    public record Customer
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public string BankAccountNumber { get; init; }
    }
}
