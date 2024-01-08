namespace Mc2.Framework.Domain;

public interface IUnitOfWork
{
    void Begin();
    void Commit();
    void Rollback();

    Task BeginAsync();
    Task CommitAsync();
    Task RollbackAsync();
}