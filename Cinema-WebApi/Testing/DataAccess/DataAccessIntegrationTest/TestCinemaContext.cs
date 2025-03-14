using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccessIntegrationTest
{
    internal class TestCinemaContext : CinemaContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestCinemaDb;Trusted_Connection=True;");
        }
    }
}
