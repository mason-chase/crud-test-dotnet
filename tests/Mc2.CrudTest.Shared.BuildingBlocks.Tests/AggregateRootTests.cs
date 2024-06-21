using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

namespace Mc2.CrudTest.Shared.BuildingBlocks.Tests;

public class AggregateRootTests
{
    public record FakeEvent : IDomainEvent<int>
    {
        public string Name { get; init; }
    }

    public record FakeAggregateRoot : AggregateRoot<int>
    {
        public string Name { get; set; }

        protected override void OnAppend(IDomainEvent<int> @event)
        {
        }
    }

    [Fact]
    public void Test1()
    {
    }
}