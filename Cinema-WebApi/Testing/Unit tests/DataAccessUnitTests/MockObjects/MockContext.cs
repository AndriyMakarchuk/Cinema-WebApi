using Microsoft.EntityFrameworkCore;

namespace DataAccessUnitTesting.MockObjects
{
    public class MockContext : DbContext
    {
        public virtual DbSet<EntityMock> Entities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityMock>()
                .HasKey(c => c.Id);
        }
    }
}
