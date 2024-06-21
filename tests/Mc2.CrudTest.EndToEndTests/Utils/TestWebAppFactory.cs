using Mc2.CrudTest.Presentation.Server;
using Mc2.CrudTest.Shared.DataStore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, DisableTestParallelization = true, MaxParallelThreads = 1)]

namespace Mc2.CrudTest.EndToEndTests.Utils;

public class TestWebAppFactory : IAsyncLifetime
{
    private readonly WebApplicationFactory<Program> _webFactory;

    public TestWebAppFactory()
    {
        _webFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                List<ServiceDescriptor> dbContextDescriptors = services.Where(x => x.ServiceType == typeof(DbContextOptions<AppDbContext>)).ToList();
                if (dbContextDescriptors.Any())
                {
                    foreach (ServiceDescriptor descriptor in dbContextDescriptors)
                        services.Remove(descriptor);

                    services.Replace(ServiceDescriptor.Scoped<AppDbContext>(provider =>
                    {
                        DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;
                        return new AppDbContext(options);
                    }));
                }
            });
            builder.UseTestServer();
            builder.UseEnvironment(Environments.Development);
        });
    }

    protected IServiceProvider RootServiceProvider { get; private set; }

    protected HttpClient CreateClient()
    {
        return _webFactory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("https://www.crud.com") });
    }

    public async Task InitializeAsync()
    {
        RootServiceProvider = _webFactory.Services;

        await using AsyncServiceScope socpe = RootServiceProvider.CreateAsyncScope();
        AppDbContext dbContext = socpe.ServiceProvider.GetRequiredService<AppDbContext>();
        await dbContext.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await _webFactory.DisposeAsync();
    }
}