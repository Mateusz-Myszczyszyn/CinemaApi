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
            builder.Property(m => m.Title).IsRequired().HasMaxLength(20);
            builder.Property(m => m.Director).IsRequired().HasMaxLength(25);
            builder.Property(m => m.Description).HasMaxLength(100);
            builder.Property(m => m.Cast).HasMaxLength(50);

            builder.Property(m => m.Premiere).HasColumnType("Date");
        }
    }
}
