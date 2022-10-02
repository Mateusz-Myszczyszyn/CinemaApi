using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApi.Entities.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {

            builder.Property(a => a.City).IsRequired().HasMaxLength(20);
            builder.Property(a => a.Street).IsRequired().HasMaxLength(20);
            builder.Property(a => a.PostalCode).IsRequired().HasMaxLength(20);

            builder.HasOne(c => c.Cinema)
                .WithMany(a=>a.Addresses)
                .HasForeignKey(c => c.CinemaId);
            
            builder.HasKey(a => a.Id);

            
        }
    }
}
