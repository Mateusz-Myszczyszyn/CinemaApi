using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Title).IsRequired();
            builder.Property(m => m.Director).IsRequired();
            builder.Property(m => m.Description).HasMaxLength(100);

            builder.HasMany(ch => ch.CinemaHalls)
                 .WithMany(m => m.Movies)
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
