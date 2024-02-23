using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mc2.CrudTest.Presentation.EntityFrameworkCore.EntityFrameworkCore
{
    internal class CustomerManagmentDbContextFactory : IDesignTimeDbContextFactory<CustomerManagementDbContext>
    {
        public CustomerManagementDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CustomerManagementDbContext>();

            builder.UseSqlServer("Data Source=.;Initial Catalog=CustomerManagement;Integrated Security=true;TrustServerCertificate=True",
            optionBuilder => optionBuilder.MigrationsHistoryTable("MigrationHistory", "CustomerManagement"));

            return new CustomerManagementDbContext(builder.Options);
        }
    }
}
