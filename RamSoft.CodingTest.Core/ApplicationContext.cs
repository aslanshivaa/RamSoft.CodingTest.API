using Microsoft.EntityFrameworkCore;
using RamSoft.CodingTest.Core.Entities;
using RamSoft.CodingTest.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RamSoft.CodingTest.Core
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {

        }

        public DbSet<ScrumTask> ScrumTasks { get; set; }

        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {            
            modelBuilder.Seed();

            modelBuilder.Entity<ScrumTask>()
            .Property(p => p.StatusName)
            .HasDefaultValue("New");

            modelBuilder.Entity<ScrumTask>()
            .Property(p => p.StatusId)
            .HasDefaultValue(1);
        }


    }
}
