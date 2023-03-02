using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities.Configurations
{
    public class UsersIssuesConfiguration : IEntityTypeConfiguration<UsersIssues>
    {
        public void Configure(EntityTypeBuilder<UsersIssues> builder)
        {
            builder.Property(f => f.FullName).IsRequired();
            builder.Property(c => c.Message).IsRequired().HasMaxLength(150);
            builder.HasKey(d => d.Id);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(i => i.IssueName).IsRequired();
        }
    }
}
