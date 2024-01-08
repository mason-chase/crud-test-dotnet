namespace Mc2.Framework.Domain;

public class IdBase<TId>(TId id)
{
    public TId Id { get; set; } = id;
}