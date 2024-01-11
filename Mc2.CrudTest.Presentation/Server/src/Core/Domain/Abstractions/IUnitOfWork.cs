namespace Domain.Abstractions;

public interface IUnitOfWork
{
    ICustomerRepository CustomerRepository {get;}
    Task SaveChangeAsync(CancellationToken cancellationToken);
}