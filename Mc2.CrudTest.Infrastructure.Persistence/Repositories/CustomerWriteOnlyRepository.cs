using Mc2.CrudTest.Domain.Contract.Customers;
using Mc2.CrudTest.Domain.Customers.Entities.Write;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories;

internal class CustomerWriteOnlyRepository : BaseWriteOnlyRepository<Customer, Guid>, ICustomerWriteOnlyRepository
{
    public CustomerWriteOnlyRepository(WriteDbContext writeDbContext) : base(writeDbContext)
    {
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _writeDbContext.Customers
            .AsNoTracking()
            .AnyAsync(c => c.Email == email);
    }

    public async Task<bool> ExistsByEmailAsync(string email, Guid customerId)
    {
        return await _writeDbContext.Customers
            .AsNoTracking()
            .AnyAsync(c => c.Email == email && c.Id != customerId);
    }

    public async Task<bool> ExistsByFullnameAndBirthdateAsync(string firstname, string lastname, DateTime birthdate)
    {
        return await _writeDbContext.Customers
            .AsNoTracking()
            .AnyAsync(c => c.Firstname == firstname && c.Lastname == lastname && c.DateOfBirth.Date == birthdate.Date);
    }

    public async Task<bool> ExistsByFullnameAndBirthdateAsync(string firstname, string lastname, DateTime birthdate, Guid customerId)
    {
        return await _writeDbContext.Customers
            .AsNoTracking()
            .AnyAsync(c => c.Firstname == firstname && c.Lastname == lastname && c.DateOfBirth.Date == birthdate.Date && c.Id != customerId);
    }
}
