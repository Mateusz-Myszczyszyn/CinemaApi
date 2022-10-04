using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApi.Entities.Configurations
{
    public class SeatReservationConfiguration : IEntityTypeConfiguration<SeatReservation>
    {
        public void Configure(EntityTypeBuilder<SeatReservation> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(sr => sr.SeatReservations)
                .HasForeignKey(u => u.UserId);


            builder.Property(i => i.IsReserved).IsRequired().HasDefaultValue(false);
            builder.Property(i => i.Payed).IsRequired().HasDefaultValue(false);
            builder.Property(i => i.Active).IsRequired().HasDefaultValue(false);

            builder.HasKey(s => s.Id);
            
        }
    }
}

