using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.Mappings
{
    public class ReportMapping : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(ı => ı.Id);
            builder.Property(ı => ı.Id).UseIdentityColumn();


            builder.Property(ı => ı.Definition).HasMaxLength(100).IsRequired();
            builder.Property(ı => ı.Detail).HasColumnType("NVARCHAR(MAX)");

            builder.HasOne(ı => ı.Task).WithMany(ı => ı.Report).HasForeignKey(ı => ı.TaskId);
        }
    }
}
