using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities.Configurations
{
    public class HallSeatsConfiguration : IEntityTypeConfiguration<HallSeats>
    {
        public void Configure(EntityTypeBuilder<HallSeats> builder)
        {
            builder.HasOne(c => c.CinemaHall)
                .WithMany(c => c.HallSeats)
                .HasForeignKey(c => c.CinemaHallId);

            builder.Property(c => c.Seat).IsRequired();
            builder.Property(c => c.Row).IsRequired();

            builder.HasMany(c => c.SeatReservations)
                .WithOne(s => s.HallSeats)
                .HasForeignKey(s => s.HallSeatId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
