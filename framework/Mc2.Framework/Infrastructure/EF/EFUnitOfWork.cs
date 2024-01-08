using System.Data;
using Mc2.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mc2.Framework.Infrastructure.EF;

public class EfUnitOfWork(DbContext dbContext) : IUnitOfWork
{
    private IDbContextTransaction _transaction;

    public void Begin()
    {
        _transaction = dbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);
    }

    public void Commit()
    {
        dbContext.SaveChanges();
        _transaction.Commit();
    }

    public void Rollback()
    {
       _transaction.Rollback();
    }

    public async Task BeginAsync()
    {
        _transaction = await dbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
    }

    public async Task CommitAsync()
    {
        await dbContext.SaveChangesAsync();
        await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        await _transaction.RollbackAsync();
    }
}