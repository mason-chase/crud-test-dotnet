using MediatR;

namespace Mc2.CrudTest.Shared.BuildingBlocks.CQRS;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}