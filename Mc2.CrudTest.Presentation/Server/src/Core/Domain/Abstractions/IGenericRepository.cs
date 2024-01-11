namespace Domain.Abstractions;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> All();
    Task<T?> GetById(int id);
    Task<T> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(int id);

}