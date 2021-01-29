using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(ı => ı.Name).HasMaxLength(100);
            builder.Property(ı => ı.SurName).HasMaxLength(100);

            builder.HasMany(ı => ı.Tasks).WithOne(ı => ı.User).HasForeignKey(ı => ı.UserId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
