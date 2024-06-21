namespace Mc2.CrudTest.Shared.BuildingBlocks.Stores;

public interface IReadModelRepository<TReadModel> where TReadModel : class
{
    Task<TReadModel?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}