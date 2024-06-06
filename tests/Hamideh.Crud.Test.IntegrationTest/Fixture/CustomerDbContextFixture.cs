
using Hamideh.Crud.Test.Infrastracture.Persistence.SqlContext;
using Microsoft.EntityFrameworkCore;


namespace Hamideh.Crud.Test.IntegrationTests.Fixtures;

public class CustomerDbContextFixture : IDisposable
{
    protected CustomerDbContext BuildDbContext(DbContextOptions<CustomerDbContext> options)
    {
        return new CustomerDbContext(options);
    }

    public CustomerDbContext BuildDbContext(string dbName)
    {
        try
        {
            var _options = new DbContextOptionsBuilder<CustomerDbContext>()
                            .UseInMemoryDatabase(dbName)
                            .EnableSensitiveDataLogging()
                            .Options;

            var db = BuildDbContext(_options);
            db.Database.EnsureCreated();

            return BuildDbContext(_options);
        }
        catch (Exception ex)
        {
            throw new Exception($"unable to connect to db.", ex);
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}