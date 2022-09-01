using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities.Configurations
{
    public class CinemaHallConfiguration : IEntityTypeConfiguration<CinemaHall>
    {
        public void Configure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder.HasMany(ch => ch.Movies)
                 .WithMany(m => m.CinemaHalls)
                 .UsingEntity<MoviePerforming>(

                mp => mp.HasOne(m => m.Movie)
                .WithMany()
                .HasForeignKey(m => m.MovieId),

                mp => mp.HasOne(c => c.CinemaHall)
                .WithMany()
                .HasForeignKey(c => c.CinemaHallId),

                mp =>
                {
                    mp.HasKey(x => new { x.MovieId, x.CinemaHallId });
                }
          );

              
            
        }
    }
}
