using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(c => c.Cinema)
                .WithMany(a=>a.Addresses)
                .HasForeignKey(c => c.CinemaId);

            builder.Property(a => a.City).IsRequired().HasMaxLength(10);
            builder.Property(a => a.Street).IsRequired();
            builder.Property(a => a.PostalCode).IsRequired();
        }
    }
}
