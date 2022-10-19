﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScooterRental.DB;

namespace ScooterRental.DB.Migrations
{
    [DbContext(typeof(ScooterDbContext))]
    [Migration("20221019144945_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ScooterRental.Core.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PricePerMinute")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("RentEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RentStart")
                        .HasColumnType("TEXT");

                    b.Property<string>("ScooterId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("ScooterRental.Core.Scooter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRented")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PricePerMinute")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Scooters");
                });
#pragma warning restore 612, 618
        }
    }
}
