using Mc2.CrudTest.Contracts;

namespace Mc2.CrudTest.Application.Handlers;

public class QueryHandlers<TRequest, TResult> : IRequestHandler<TRequest, TResult>
{
    private readonly IQuery<TRequest, TResult> _query;

    public QueryHandlers(IQuery<TRequest, TResult> query) => _query = query;

    public async Task<TResult> Handle(TRequest request)
    {
        return await _query.Execute(request);
    }
}