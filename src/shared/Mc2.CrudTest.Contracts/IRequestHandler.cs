namespace Mc2.CrudTest.Contracts;

public interface IRequestHandler<in TRequest, TResult>
{
    Task<TResult> Handle(TRequest request);
}