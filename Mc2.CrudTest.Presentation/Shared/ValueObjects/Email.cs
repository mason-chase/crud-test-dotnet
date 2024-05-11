namespace Mc2.CrudTest.Presentation.Shared.ValueObjects
{
    public record Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Invalid email format.", nameof(value));

            Value = value;
        }


    }
}