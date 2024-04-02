namespace Application.Common.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<bool> Exists(int id);
    Task<T> Add(T entity);
    Task<List<T>> AddRange(List<T> entities);
    Task Update(T entity);
    Task Delete(T entity);
    
   
    
    


}

