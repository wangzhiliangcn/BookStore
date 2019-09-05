using BookStore.Data.Migrations;
using BookStore.Domain;
using System.Data.Entity;

namespace BookStore.Data
{
    public partial class IMSContext : DbContext
    {
        public IMSContext() : base("name=IMSDB_New")
        {
            //Seed
            Database.SetInitializer(new Configuration());
        }

        public IMSContext(string connStr) : base(connStr)
        {
            Database.SetInitializer(new Configuration());
        }

        public virtual DbSet<SysMenu> SysMenu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
