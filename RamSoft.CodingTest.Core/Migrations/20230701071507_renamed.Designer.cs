﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RamSoft.CodingTest.Core;

namespace RamSoft.CodingTest.Core.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230701071507_renamed")]
    partial class renamed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RamSoft.CodingTest.Core.Entities.ScrumTask", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompletedHours")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OriginalEstimate")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("TaskId");

                    b.HasIndex("StatusId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            TaskId = 1,
                            Description = " Find each and every service missing the logs and add necessary logs for each method",
                            Title = "Add Logs to existing repos and services"
                        },
                        new
                        {
                            TaskId = 2,
                            Description = " Implement on push strategy to the employee component",
                            Title = "Amend component to use change detection strategy"
                        });
                });

            modelBuilder.Entity("RamSoft.CodingTest.Core.Entities.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            StatusName = "New"
                        },
                        new
                        {
                            StatusId = 2,
                            StatusName = "Active"
                        },
                        new
                        {
                            StatusId = 3,
                            StatusName = "InProgress"
                        },
                        new
                        {
                            StatusId = 4,
                            StatusName = "Completed"
                        });
                });

            modelBuilder.Entity("RamSoft.CodingTest.Core.Entities.ScrumTask", b =>
                {
                    b.HasOne("RamSoft.CodingTest.Core.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
