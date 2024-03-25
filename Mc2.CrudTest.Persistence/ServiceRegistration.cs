using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Persistence.DbContext;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceService(this IServiceCollection services)
    {
        services.AddSingleton<IMongoDbContext, MongoDbContext>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}