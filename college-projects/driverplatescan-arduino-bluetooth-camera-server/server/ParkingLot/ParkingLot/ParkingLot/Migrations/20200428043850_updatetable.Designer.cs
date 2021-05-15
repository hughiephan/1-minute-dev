﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingLot.Models.DAO;

namespace ParkingLot.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200428043850_updatetable")]
    partial class updatetable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkingLot.Models.DAO.Parking", b =>
                {
                    b.Property<long>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicencePlateImgIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicencePlateImgOut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicencePlateIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicencePlateOut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ParkingCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TimeOut")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TotalHours")
                        .HasColumnType("int");

                    b.Property<int>("UserUidIn")
                        .HasColumnType("int");

                    b.Property<int?>("UserUidOut")
                        .HasColumnType("int");

                    b.HasKey("Uid");

                    b.ToTable("Parkings");
                });

            modelBuilder.Entity("ParkingLot.Models.DAO.ParkingCost", b =>
                {
                    b.Property<int>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Uid");

                    b.ToTable("ParkingCosts");
                });

            modelBuilder.Entity("ParkingLot.Models.DAO.User", b =>
                {
                    b.Property<int>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Uid");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
