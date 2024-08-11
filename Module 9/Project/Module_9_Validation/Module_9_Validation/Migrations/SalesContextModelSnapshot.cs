﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Module_9_Validation.Models;

#nullable disable

namespace Module_9_Validation.Migrations
{
    [DbContext(typeof(SalesContext))]
    partial class SalesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Module_9_Validation.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime?>("DOB")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfHire")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            DOB = new DateTime(1956, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Ada",
                            Lastname = "Lovelace",
                            ManagerId = 0
                        },
                        new
                        {
                            EmployeeId = 2,
                            DOB = new DateTime(1966, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Katherine",
                            Lastname = "Johnson",
                            ManagerId = 1
                        },
                        new
                        {
                            EmployeeId = 3,
                            DOB = new DateTime(1975, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfHire = new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Grace",
                            Lastname = "Hopper",
                            ManagerId = 1
                        });
                });

            modelBuilder.Entity("Module_9_Validation.Models.Sales", b =>
                {
                    b.Property<int>("SalesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesId"));

                    b.Property<double?>("Amount")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("Quarter")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("SalesId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            SalesId = 1,
                            Amount = 23456.0,
                            EmployeeId = 2,
                            Quarter = 4,
                            Year = 2019
                        },
                        new
                        {
                            SalesId = 2,
                            Amount = 34567.0,
                            EmployeeId = 2,
                            Quarter = 1,
                            Year = 2020
                        },
                        new
                        {
                            SalesId = 3,
                            Amount = 19876.0,
                            EmployeeId = 3,
                            Quarter = 4,
                            Year = 2019
                        },
                        new
                        {
                            SalesId = 4,
                            Amount = 31009.0,
                            EmployeeId = 3,
                            Quarter = 1,
                            Year = 2020
                        });
                });

            modelBuilder.Entity("Module_9_Validation.Models.Sales", b =>
                {
                    b.HasOne("Module_9_Validation.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
