using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using DataAccess.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DataAccess.Entities.MovieInformation;
using DataAccess.Configurations.MovieInformationConfigurations;
using DataAccess.Extencions.Data;

namespace DataAccess
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreMovie> MovieGenres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public CinemaContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CinemaDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GenreMovieConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieActorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.SeedGenreList();
            modelBuilder.ApplyConfiguration(new CinemaHallConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.SeedMovieList();
        }

    }
}