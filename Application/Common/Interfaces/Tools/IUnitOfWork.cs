namespace Application.Common.Interfaces.Tools;

public interface IUnitOfWork
{
    void BeginTransaction();
    Task CommitTransaction();
    void RollBack();
    void Dispose();
    Task<int> Save();

}
