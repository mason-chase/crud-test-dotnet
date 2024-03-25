using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Persistence.Utils;
using MongoDB.Driver;

namespace Mc2.CrudTest.Persistence.DbContext;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;
    public IClientSessionHandle Session { get; set; }
    private readonly List<Func<Task>> _commands;
    private MongoClient MongoClient { get; set; }

    public MongoDbContext()
    {
        MongoClient  = new MongoClient(Util.MongoDbConnectionString);
        _database = MongoClient.GetDatabase(Util.CustomerCollection);
        _commands = new List<Func<Task>>();
    }
    
    public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
    {
        return _database.GetCollection<TEntity>(name);
    }
    
    public void Dispose()
    {
        Session?.Dispose();
        GC.SuppressFinalize(this);    
    }
    public async Task<int> SaveChanges()
    {
        using (Session = await MongoClient.StartSessionAsync())
        {
            Session.StartTransaction();
            var commandTasks = _commands.Select(c => c());
            await Task.WhenAll(commandTasks);

            await Session.CommitTransactionAsync();
        }
        
        return _commands.Count;
    }
    public void AddCommand(Func<Task> func)
    {
        _commands.Add(func);    
    }
    
}