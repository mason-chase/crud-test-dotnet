using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Contract;
using Mc2.CrudTest.Infrastructure.Extensions;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Text.Json;

namespace Mc2.CrudTest.Infrastructure.Persistence;

internal class UnitOfWork : IUnitOfWork, IDisposable
{
    private bool _disposed;
    private readonly WriteDbContext _writeDbContext;
    private readonly ILogger<UnitOfWork> _logger;
    private readonly IMediator _mediator;
    private readonly IEventStoreRepository _eventStoreRepository;

    public UnitOfWork(
        WriteDbContext dbContext,
        ILogger<UnitOfWork> logger,
        IMediator mediator,
        IEventStoreRepository eventStoreRepository)
    {
        _writeDbContext = dbContext;
        _logger = logger;
        _mediator = mediator;
        _eventStoreRepository = eventStoreRepository;
    }

    public async Task SaveChangesAsync()
    {
        var strategy = _writeDbContext.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _writeDbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            _logger.LogInformation("----- Begin transaction: '{TransactionId}'", transaction.TransactionId);

            try
            {
                var (domainEvents, eventStores) = BeforeSaveChanges();

                var rowsAffected = await _writeDbContext.SaveChangesAsync();

                _logger.LogInformation("----- Commit transaction: '{TransactionId}'", transaction.TransactionId);

                await transaction.CommitAsync();
                await AfterSaveChangesAsync(domainEvents, eventStores);

                _logger.LogInformation(
                    "----- Transaction successfully confirmed: '{TransactionId}', Rows Affected: {RowsAffected}",
                    transaction.TransactionId,
                    rowsAffected);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "An unexpected exception occurred while committing the transaction: '{TransactionId}', message: {Message}",
                    transaction.TransactionId,
                    ex.Message);

                await transaction.RollbackAsync();

                throw;
            }
        });
    }

    private (IReadOnlyList<BaseEvent> domainEvents, IReadOnlyList<EventStore> eventStores) BeforeSaveChanges()
    {
        var domainEntities = _writeDbContext
            .ChangeTracker
            .Entries<BaseEntity>()
            .Where(entry => entry.Entity.DomainEvents.Any())
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(entry => entry.Entity.DomainEvents)
            .ToList();

        var eventStores = domainEvents
            .ConvertAll(@event => new EventStore(@event.AggregateId, @event.GetGenericTypeName(), JsonSerializer.Serialize(@event, @event.GetType())));

        domainEntities.ForEach(entry => entry.Entity.ClearDomainEvents());

        return (domainEvents.AsReadOnly(), eventStores.AsReadOnly());
    }

    private async Task AfterSaveChangesAsync(IReadOnlyList<BaseEvent> domainEvents, IReadOnlyList<EventStore> eventStores)
    {
        if (!domainEvents.Any() || !eventStores.Any())
        {
            return;
        }

        var tasks = domainEvents
            .AsParallel()
            .Select(@event => _mediator.Publish(@event))
            .ToList();

        await Task.WhenAll(tasks);
        await _eventStoreRepository.StoreAsync(eventStores);
    }

    ~UnitOfWork() => Dispose(false);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _writeDbContext.Dispose();
            _eventStoreRepository.Dispose();
        }

        _disposed = true;
    }
}
