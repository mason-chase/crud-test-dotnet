using MediatR;

namespace Mc2.CrudTest.Shared.BuildingBlocks.CQRS;

public interface ICommand : IRequest
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}