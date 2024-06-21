using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.GetCustomer;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;
using Mc2.CrudTest.Shared.DataStore;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Modules.Customers.Infrastructure;

public class CustomerReadModelRepository : IReadModelRepository<CustomerDto>
{
    private readonly AppDbContext _context;

    public CustomerReadModelRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Customers
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new CustomerDto
            {
                Id = id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = $"+{x.PhoneNumber.ToString()}",
                Email = x.Email,
                BankAccountNumber = x.BankAccountNumber
            })
            .SingleOrDefaultAsync(cancellationToken);
    }
}