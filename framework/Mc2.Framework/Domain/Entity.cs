namespace Mc2.Framework.Domain;

public class Entity<TKey>
{
    public Entity(TKey id) => Id = id;
    
    protected Entity()
    {
    }

    public TKey Id { get; protected set; }
}