using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CinemaHallConfiguration : IEntityTypeConfiguration<CinemaHall>
    {
        public void Configure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Places_rows_amount).IsRequired();
            builder.Property(x => x.Places_columns_amount).IsRequired();
        }
    }
}