namespace Mc2.CrudTest.Domain.IRepos;

public interface IRepo<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(int id);
    Task<List<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}