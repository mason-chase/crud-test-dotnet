using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Persistence.DbContexts;

internal abstract class BaseDbContext<TContext> : DbContext where TContext : DbContext
{
    protected BaseDbContext(DbContextOptions<TContext> dbOptions)
        : base(dbOptions)
    {
    }
}
