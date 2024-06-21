namespace Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

public interface IDomainEvent
{
}

public interface IDomainEvent<TId> : IDomainEvent
{
}