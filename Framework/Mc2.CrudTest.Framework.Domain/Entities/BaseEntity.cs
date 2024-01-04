
namespace Mc2.CrudTest.Framework.Domain.Entities
{


    public abstract class BaseEntity<TId> where TId : IEquatable<TId>
    {
        public TId Id { get; protected set; }

    }
}
