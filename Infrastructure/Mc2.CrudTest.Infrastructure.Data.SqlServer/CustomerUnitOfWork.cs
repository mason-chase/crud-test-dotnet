using Mc2.CrudTest.Framework.Domain.Data;


namespace Mc2.CrudTest.Infrastructure.Data.SqlServer
{
    public class CustomerUnitOfWork : IUnitOfWork
    {
        private readonly CustomerDbContext advertismentDbContext;

        public CustomerUnitOfWork(CustomerDbContext advertismentDbContext)
        {
            this.advertismentDbContext = advertismentDbContext;
        }
        public int Commit()
        {
            return advertismentDbContext.SaveChanges();
        }
    }
}
