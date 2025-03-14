using DataAccess.Entities;
using DataAccess.Entities.MovieInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            // Foreign key
            builder.HasKey(s => s.Id);

            // Required field
            builder.Property(s => s.MovieId)
                .IsRequired();

            // Field MovieId: ForeignKey to Movie
            builder.HasOne<Movie>()
                .WithMany()
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade); // Remove all related sessions when Movie is deleted

            // Required field
            builder.Property(s => s.HallId)
                .IsRequired();

            // Field HallId: ForeignKey to Hall
            builder.HasOne<CinemaHall>()
                .WithMany()
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.Cascade); // Remove all related sessions when Hall is deleted

            // Required field
            builder.Property(s => s.SessionDate)
                .IsRequired();
        }
    }
}