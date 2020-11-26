using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_job.Models
{
    public class JobContext: DbContext
    {
        public JobContext(DbContextOptions<JobContext> options)
                     : base(options)
        {
        }

        public DbSet<job> job { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<job>(entity =>
            {
                entity.Property(e => e.JobTitle).IsRequired();
            });
        }
    }
}
