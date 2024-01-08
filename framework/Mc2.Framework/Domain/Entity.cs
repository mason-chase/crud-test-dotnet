namespace Mc2.Framework.Domain;

public class Entity<TKey>
{
    public Entity(TKey entityId) => EntityId = entityId;
    
    protected Entity()
    {
    }

    public TKey EntityId { get; protected set; }
}