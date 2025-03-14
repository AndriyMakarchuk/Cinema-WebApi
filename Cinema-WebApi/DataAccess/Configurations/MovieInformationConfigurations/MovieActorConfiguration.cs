using DataAccess.Entities.MovieInformation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations.MovieInformationConfigurations
{
    internal class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(am => new { am.MovieId, am.ActorId });

            builder.HasOne(am => am.Actor)
                .WithMany(a => a.Movies)
                .HasForeignKey(am => am.ActorId)
                .OnDelete(DeleteBehavior.Cascade);



            builder.HasOne(am => am.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(am => am.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
