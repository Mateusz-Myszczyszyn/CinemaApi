using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities.Configurations
{
    public class ScreenPlayConfiguration : IEntityTypeConfiguration<ScreenPlay>
    {
        public void Configure(EntityTypeBuilder<ScreenPlay> builder)
        {
            builder.Property(s => s.ShowTime).IsRequired();
            builder.HasOne(mp => mp.MoviePerforming)
                .WithMany(mp => mp.ScreenPlays)
                .HasForeignKey(mp => mp.MoviePerformingId);

            builder.HasMany(mp => mp.SeatReservations)
                .WithOne(mp => mp.ScreenPlay)
                .HasForeignKey(mp => mp.ScreenPlayId).OnDelete(DeleteBehavior.NoAction);
                
        }
    }
}
