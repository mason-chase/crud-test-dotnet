using MongoDB.Driver;

namespace Mc2.CrudTest.Application.Interfaces;

public interface IMongoDbContext
{
    void AddCommand(Func<Task> func);
    IMongoCollection<TEntity> GetCollection<TEntity>(string name);
    Task<int> SaveChanges();
    
}