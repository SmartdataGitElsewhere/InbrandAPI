using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Inbrand.CoreEntities;
using Inbrand.CoreEntityes;

namespace RepositoryLayer.DA
{
    public class DB : DbContext
    {
        public DB() : base("InbrandTestServer")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<EmployeeContext>(new MigrateDatabaseToLatestVersion<EmployeeContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StoreSystemIP> StoreSystemIPs { get; set; }
    }
}
