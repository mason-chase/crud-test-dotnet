namespace Mc2.CrudTest.Shared.Abstraction.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> Query<TResult>(IQuery<TResult> query);
    }
}
