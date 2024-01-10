namespace Mc2.CrudTest.Infrastructure.Persistence;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
