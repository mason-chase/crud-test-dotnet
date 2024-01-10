namespace Domain.Abstractions;

public interface IUnitOfWork
{
    ICustomerRepository CustomerRepository {get;}
}