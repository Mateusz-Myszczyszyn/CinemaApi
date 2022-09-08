using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role() { Id = 1, Name = "Admin" },
                            new Role() { Id = 2, Name = "User" },
                            new Role() { Id = 3, Name = "Menager" },
                            new Role() { Id = 4, Name = "Worker" });
        }
    }
}
