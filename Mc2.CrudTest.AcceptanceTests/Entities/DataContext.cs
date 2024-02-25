using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions buildOptions)
             : base(buildOptions)
        {

        }

        public virtual DbSet<Customer> M_Customer { get; set; }
    }
}

