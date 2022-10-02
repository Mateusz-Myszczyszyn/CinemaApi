using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities.Configurations
{
    public class SeetReservingConfiguration : IEntityTypeConfiguration<SeetReserving>
    {
        public void Configure(EntityTypeBuilder<SeetReserving> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(sr => sr.SeetReservings)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(ch=>ch.CinemaHall)
                .WithMany(sr=>sr.SeetReservings)
                .HasForeignKey(ch=>ch.CinemaHallId);

            builder.Property(i => i.IsReserved).IsRequired().HasDefaultValue(false);
            builder.Property(i => i.Seat).IsRequired();
            builder.Property(i => i.Row).IsRequired();


            builder.HasKey(x => new { x.Id, x.Row,x.Seat});
        }
    }
}

