using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccessIntegrationTest
{
    internal class TestCinemaContext : CinemaContext
    {
        public TestCinemaContext()
        {
            if (Database != null)
            {
                Database.EnsureDeleted();
            }
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestCinemaDb;Trusted_Connection=True;");
        }
        protected override void SeedData(ModelBuilder modelBuilder)
        {

        }
    }
}
