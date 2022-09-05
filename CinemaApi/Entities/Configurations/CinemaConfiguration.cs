using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Addresses).IsRequired();

            builder.HasMany(c => c.CinemaHalls)
                .WithOne(c => c.Cinema)
                .HasForeignKey(f => f.CinemaId);
        }
    }
}
