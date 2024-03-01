
namespace Mc2.CrudTest.Presentation.Shared
{
    /// <summary>
    /// Represents the base class for entities
    /// </summary>
    public abstract class BaseEntity<PKType>
    {
        public PKType Id { get; set; }

    }
}