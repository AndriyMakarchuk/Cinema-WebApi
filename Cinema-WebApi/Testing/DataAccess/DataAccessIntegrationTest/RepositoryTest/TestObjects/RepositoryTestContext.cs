using Microsoft.EntityFrameworkCore;

namespace DataAccessUnitTesting.MockObjects
{
    public class RepositoryTestContext : DbContext
    {
        public virtual DbSet<TestEntity> Entities { get; set; }
        public RepositoryTestContext()
        {
            if(Database != null)
            {
                Database.EnsureDeleted();
            }
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RepositoryTestDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestEntity>()
                .HasKey(c => c.Id);
        }
    }
}
