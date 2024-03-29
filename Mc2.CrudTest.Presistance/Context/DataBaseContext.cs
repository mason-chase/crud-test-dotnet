using Mc2.CrudTest.Application.Interfaces.Context;
using Mc2.CrudTest.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presistance.Context
{
    public class DataBaseContext : DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique();
            builder.Entity<Customer>().HasIndex(u => u.Email).IsUnique();
        }
    }
}
