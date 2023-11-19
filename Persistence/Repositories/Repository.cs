using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class Repository<TEntity> : Domain.Repositories.IRepository<TEntity> where TEntity : class
{
	protected readonly DbContext Context;
	protected readonly DbSet<TEntity> Entities;

	public Repository(DbContext context)
	{
		Context = context;
		Entities = Context.Set<TEntity>();
	}

	public TEntity? Get(int id)
	{
		return Entities.Find(id);
	}

	public async Task<TEntity?> GetAsync(int id)
	{
		return await Entities.FindAsync(id);
	}

	public IEnumerable<TEntity> GetAll()
	{
		return Entities.ToList();
	}

	public async Task<IEnumerable<TEntity>> GetAllAsync()
	{
		return await Entities.ToListAsync();
	}

	public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
	{
		return Entities.Where(predicate);
	}

	public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
	{
		return await Entities.Where(predicate).ToListAsync();
	}

	public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
	{
		return Entities.SingleOrDefault(predicate);
	}

	public Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
	{
		return Entities.SingleOrDefaultAsync(predicate);
	}

	public void Add(TEntity entity)
	{
		Entities.Add(entity);
	}

	public async Task AddAsync(TEntity entity)
	{
		await Entities.AddAsync(entity);
	}

	public void AddRange(IEnumerable<TEntity> entities)
	{
		Entities.AddRange(entities);
	}

	public async Task AddRangeAsync(IEnumerable<TEntity> entities)
	{
		await Entities.AddRangeAsync(entities);
	}

	public void Remove(TEntity entity)
	{
		Entities.Remove(entity);
	}

	public void RemoveRange(IEnumerable<TEntity> entities)
	{
		Entities.RemoveRange(entities);
	}
}