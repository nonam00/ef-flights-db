﻿// <auto-generated />
using System;
using FlightsDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightsDb.Migrations
{
    [DbContext(typeof(FlightsDbContext))]
    partial class FlightsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightsDb.Models.Airport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Destinations", (string)null);
                });

            modelBuilder.Entity("FlightsDb.Models.Passenger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("PassportNumber");

                    b.ToTable("Passengers", t =>
                        {
                            t.HasCheckConstraint("CK_Passengers_BirthDate", "DATEDIFF(YEAR, BirthDate, GETDATE()) > 0");
                        });

                    b.HasDiscriminator<string>("Discriminator").HasValue("Passenger");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FlightsDb.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("PassengerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasAlternateKey("Number");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TripId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("FlightsDb.Models.Trip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArrivalAirportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartureAirportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SeatsNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasAlternateKey("Number");

                    b.HasIndex("ArrivalAirportId");

                    b.HasIndex("DepartureAirportId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("FlightsDb.Models.Beneficiary", b =>
                {
                    b.HasBaseType("FlightsDb.Models.Passenger");

                    b.Property<decimal>("Sale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,2)")
                        .HasDefaultValueSql("0.1");

                    b.ToTable(t =>
                        {
                            t.HasCheckConstraint("CK_Passengers_BirthDate", "DATEDIFF(YEAR, BirthDate, GETDATE()) > 0");
                        });

                    b.HasDiscriminator().HasValue("Beneficiary");
                });

            modelBuilder.Entity("FlightsDb.Models.Ticket", b =>
                {
                    b.HasOne("FlightsDb.Models.Passenger", "Passenger")
                        .WithMany("Tickets")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("FlightsDb.Models.Trip", "Trip")
                        .WithMany("Tickets")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("FlightsDb.Models.Trip", b =>
                {
                    b.HasOne("FlightsDb.Models.Airport", "ArrivalAirport")
                        .WithMany("ArrivalTrips")
                        .HasForeignKey("ArrivalAirportId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Trips_ArrivalAirport");

                    b.HasOne("FlightsDb.Models.Airport", "DepartureAirport")
                        .WithMany("DepartureTrips")
                        .HasForeignKey("DepartureAirportId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Trips_DepartureAirport");

                    b.Navigation("ArrivalAirport");

                    b.Navigation("DepartureAirport");
                });

            modelBuilder.Entity("FlightsDb.Models.Airport", b =>
                {
                    b.Navigation("ArrivalTrips");

                    b.Navigation("DepartureTrips");
                });

            modelBuilder.Entity("FlightsDb.Models.Passenger", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("FlightsDb.Models.Trip", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
