using Application.Common.Interfaces.Tools;

namespace Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CrudTestDbContext _context;

    public UnitOfWork(CrudTestDbContext context)
    {
        _context = context;
    }
    public void BeginTransaction()
    {
         _context.Database.BeginTransaction();
    }

    public async Task CommitTransaction()
    {
        await Save();
        _context.Database.CommitTransaction();
    }

    public void RollBack()
    {
       _context.Database.RollbackTransaction();
    }

    public void Dispose()
    {
        _context.Database.CurrentTransaction.Dispose();
    }

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }



}
