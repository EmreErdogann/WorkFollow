using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.Mappings
{
    public class TaskMapping : IEntityTypeConfiguration<Taskk>
    {

        public void Configure(EntityTypeBuilder<Taskk> builder)
        {
            builder.HasKey(ı => ı.Id);
            builder.Property(ı => ı.Id).UseIdentityColumn();

            builder.Property(ı => ı.Name).HasMaxLength(250);
            builder.Property(ı => ı.Explanation).HasColumnType("ntext");

            builder.HasOne(ı => ı.Urgency).WithMany(ı => ı.Tasks).HasForeignKey(ı => ı.UrgencyId);
        }
    }
}
