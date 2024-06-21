using MediatR;

namespace Mc2.CrudTest.Shared.BuildingBlocks.CQRS;

public interface ICommandHandler<in TCommand> :
    ICommand, IRequestHandler<TCommand>
    where TCommand : ICommand, IRequest
{
}

public interface ICommandHandler<in TCommand, TResponse> :
    ICommand<TResponse>, IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>, IRequest<TResponse>
{
}