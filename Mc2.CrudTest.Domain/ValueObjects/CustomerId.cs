using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record CustomerId
    {
        public Guid Value { get;}
        public CustomerId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new CustomerIdEmptyException();
            }
            Value = value;
        }
        public static implicit operator Guid(CustomerId value)=> value.Value;
        public static implicit operator CustomerId(Guid id)=>new CustomerId(id);
    }
}
