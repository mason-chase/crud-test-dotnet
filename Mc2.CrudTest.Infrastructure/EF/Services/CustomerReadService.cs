using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Infrastructure.EF.Contexts;
using Mc2.CrudTest.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
namespace Mc2.CrudTest.Infrastructure.EF.Services
{
    internal sealed class CustomerReadService: ICustomerReadService
    {
        private readonly DbSet<CustomerReadModel> _customers;
        public CustomerReadService(ReadDbContext readDbContext)
        {
            _customers = readDbContext.Customers;
        }
        public async Task<bool> Exists(string firstName, string lastName, DateOnly birthday)
        {
            var fullName= FullNameReadModel.Create(firstName+","+ lastName);
            return await _customers.AnyAsync(c => c.FullName == fullName && c.Birthday == birthday);
        }
        public async Task<bool> Exists(string email, Guid id)
        {
            return await _customers.AnyAsync(c => c.Email == email && c.Id!=id);
        }
    }
}
