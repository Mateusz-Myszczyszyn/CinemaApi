using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities.Configurations
{
    public class MoviePerformingConfiguration : IEntityTypeConfiguration<MoviePerforming>
    {
        public void Configure(EntityTypeBuilder<MoviePerforming> builder)
        {
            builder.Property(x => x.MovieShowDates).HasColumnName("Movie_Shows");
        }
    }
}
