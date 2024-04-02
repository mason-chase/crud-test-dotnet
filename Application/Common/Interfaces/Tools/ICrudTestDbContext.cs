using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Tools
{
    public interface ICrudTestDbContext
    {
        DbSet<Customer> Customers { get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
