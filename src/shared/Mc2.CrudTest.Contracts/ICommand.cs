namespace Mc2.CrudTest.Contracts;

public interface ICommand<in TRequest, TResult>
{
    Task<TResult> Execute(TRequest request);
}