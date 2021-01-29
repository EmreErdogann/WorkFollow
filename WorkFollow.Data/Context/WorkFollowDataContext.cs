using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkFollow.Data.Mappings;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.DataContext
{
    public class WorkFollowDataContext : IdentityDbContext<User, Role, int>
    {
    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=EMRE; Database=WorkFollowDatabase; Integrated Security=TRUE;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ReportMapping());
            builder.ApplyConfiguration(new UserMapping());
            builder.ApplyConfiguration(new TaskMapping());
            builder.ApplyConfiguration(new UrgencyMapping());
            base.OnModelCreating(builder);
        }
        public DbSet<Taskk> Task { get; set; }
        public DbSet<Urgency> Urgency { get; set; }
        public DbSet<Report> Report { get; set; }
    }
}
