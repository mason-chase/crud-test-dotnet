using Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
    }
}