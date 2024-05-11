namespace Mc2.CrudTest.Presentation.Shared.ValueObjects
{
    public record BankAccount
    {
        public string Value { get; }

        public BankAccount(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("BankAccount cannot be empty.", nameof(value));

            Value = value;
        }
    }
}