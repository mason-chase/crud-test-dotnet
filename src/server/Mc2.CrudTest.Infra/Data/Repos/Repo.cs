using Mc2.CrudTest.Domain.IRepos;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infra.Data.Repos;

public class Repo<TEntity> : IRepo<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public Repo(ApplicationDbContext context) => _context = context;

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        entry.State = EntityState.Detached;
        return entry.Entity;
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}