using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.Email).IsRequired();

            builder.HasOne(r => r.Role)
                .WithMany()
                .HasForeignKey(r => r.RoleId);

            builder.HasMany(u => u.SeatReservations)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
