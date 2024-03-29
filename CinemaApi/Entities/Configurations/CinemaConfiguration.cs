﻿using Microsoft.EntityFrameworkCore;
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
            builder.Property(c => c.Owner).IsRequired();
            builder.Property(c => c.WorkersQuantity).HasDefaultValue(100);


            /*builder.HasData(new Cinema() { Id = 1, Owner = "Lebovsky", Name = "CinemaCity" },
                            new Cinema() { Id = 2, Owner = "Bill", Name = "Helios" });*/
            
        }
    }
}
