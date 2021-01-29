using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.Mappings
{
    public class UrgencyMapping : IEntityTypeConfiguration<Urgency>
    {
        public void Configure(EntityTypeBuilder<Urgency> builder)
        {
            builder.HasKey(ı=> ı.Id);
            builder.Property(ı=> ı.Id).UseIdentityColumn();

            builder.Property(ı => ı.Definition).HasMaxLength(100);
        }
    }
}
