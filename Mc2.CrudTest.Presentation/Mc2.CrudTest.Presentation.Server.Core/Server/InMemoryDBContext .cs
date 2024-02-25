using Mc2.CrudTest.Presentation.Server.Core.Extentions;
using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Server.DataAccess;
using Mc2.CrudTest.Presentation.Server.DataAccess.Dao;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Mc2.CrudTest.Presentation.Server.Core.Server
{
    public class InMemoryDBContext : DbContext
    {
        public InMemoryDBContext(DbContextOptions options)
       : base(options)
        {
            SavingChanges += OnSavingChanges;
        }

        private void OnSavingChanges(object sender, SavingChangesEventArgs e)
        {
           // _cleanString();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entitiesAssembly = typeof(IEntity).Assembly;
            modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
            modelBuilder.ApplyConfigurationsFromAssembly(entitiesAssembly);
            modelBuilder.AddRestrictDeleteBehaviorConvention();
            modelBuilder.AddDefaultValueSqlConvention("Status", typeof(Status), $"{(int)Status.Enable}");

            #region Contraints

            modelBuilder.Entity<CustomerDao>().HasIndex(t => t.Email).IsUnique();
            modelBuilder.Entity<CustomerDao>().HasIndex(t => new { t.FirstName, t.LastName, t.Email }).IsUnique();

            #endregion


        }


    }
}
