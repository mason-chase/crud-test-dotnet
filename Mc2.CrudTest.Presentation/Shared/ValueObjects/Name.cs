namespace Mc2.CrudTest.Presentation.Shared.ValueObjects
{
    public class Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.", nameof(value));

            Value = value;
        }

    }
}