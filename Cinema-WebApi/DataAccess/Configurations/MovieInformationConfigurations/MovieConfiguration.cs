using DataAccess.Entities.MovieInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations.MovieInformationConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);            

            builder.Property(x => x.Title).IsRequired();

            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.TrailerLink).IsRequired();

            builder.Property(x => x.Rating).IsRequired();
        }
    }
}
