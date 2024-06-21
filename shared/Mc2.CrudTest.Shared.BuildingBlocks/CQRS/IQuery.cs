using MediatR;

namespace Mc2.CrudTest.Shared.BuildingBlocks.CQRS;

public interface IQuery<out T> : IRequest<T>
{
}