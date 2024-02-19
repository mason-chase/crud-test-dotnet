using CrudTest.Models.Entities.Marketing.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Data.Context
{
    public class MarketingDbContext: DbContext
    {
        public MarketingDbContext(DbContextOptions<MarketingDbContext> options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
