using Microsoft.EntityFrameworkCore;
using RamSoft.CodingTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RamSoft.CodingTest.Core.Extensions
{
    public static class ModelExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScrumTask>().Property(s => s.TaskId).UseIdentityColumn(1,1);
            modelBuilder.Entity<ScrumTask>().HasData(
                new ScrumTask { 
                    TaskId = 1,
                    Title = "Add Logs to existing repos and services",
                    Description = " Find each and every service missing the logs and add necessary logs for each method"
                },
                new ScrumTask
                {
                    TaskId = 2,
                    Title = "Amend component to use change detection strategy",
                    Description = " Implement on push strategy to the employee component"
                });

            modelBuilder.Entity<Status>().HasData(
                new Status { 
                    StatusId = 1,
                    StatusName = "New"
                },
                new Status
                {
                    StatusId = 2,
                    StatusName = "Active"
                },
                new Status
                {
                    StatusId= 3,
                    StatusName = "InProgress"
                },
                 new Status
                 {
                     StatusId = 4,
                     StatusName = "Completed"
                 }
                );
        }
    }
}
