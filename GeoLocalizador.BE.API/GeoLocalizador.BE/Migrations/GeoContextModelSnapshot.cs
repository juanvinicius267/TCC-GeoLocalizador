﻿// <auto-generated />
using System;
using GeoLocalizador.BE.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeoLocalizador.BE.Migrations
{
    [DbContext(typeof(GeoContext))]
    partial class GeoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeoLocalizador.BE.Models.GeoPosition", b =>
                {
                    b.Property<int>("IdPosition")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPosition");

                    b.ToTable("GeoPositions");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.Harbor", b =>
                {
                    b.Property<int>("IdHarbor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdMarineTraffic")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastChange")
                        .HasColumnType("datetime2");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHarbor");

                    b.ToTable("Harbors");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.RfidLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecordDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RfidLogs");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.TruckGeoPosition", b =>
                {
                    b.Property<int>("IdPosition")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Altitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Course")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FixMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GlonasSat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GnssSat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Humidity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTruck")
                        .HasColumnType("int");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RunStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TruckIdTruck")
                        .HasColumnType("int");

                    b.HasKey("IdPosition");

                    b.HasIndex("TruckIdTruck");

                    b.ToTable("TruckGeoPositions");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.TruckInfo", b =>
                {
                    b.Property<int>("IdTruck")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Carrier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VolumeCapacity")
                        .HasColumnType("int");

                    b.Property<int>("WeightCapacity")
                        .HasColumnType("int");

                    b.HasKey("IdTruck");

                    b.ToTable("TruckInfos");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.TruckTravel", b =>
                {
                    b.Property<int>("IdTravel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DestinationIdPosition")
                        .HasColumnType("int");

                    b.Property<int>("IdDestination")
                        .HasColumnType("int");

                    b.Property<int>("IdOrigin")
                        .HasColumnType("int");

                    b.Property<int>("IdTruck")
                        .HasColumnType("int");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OriginIdPosition")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TruckIdTruck")
                        .HasColumnType("int");

                    b.HasKey("IdTravel");

                    b.HasIndex("DestinationIdPosition");

                    b.HasIndex("OriginIdPosition");

                    b.HasIndex("TruckIdTruck");

                    b.ToTable("TruckTravels");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.VesselGeoPosition", b =>
                {
                    b.Property<int>("IdPosition")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AISSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Current_Port")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdVesselInfo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastPositionReceived")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LocationArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SpeedCourse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VesselInfoIdNavio")
                        .HasColumnType("int");

                    b.HasKey("IdPosition");

                    b.HasIndex("VesselInfoIdNavio");

                    b.ToTable("VesselGeoPositions");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.VesselInfo", b =>
                {
                    b.Property<int>("IdNavio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Call_Sign")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gross_Tonnage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Home_Port")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IMO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastChange")
                        .HasColumnType("datetime2");

                    b.Property<string>("LengthxBreadth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MMSI")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vessel_Type_Detailed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vessel_Type_Generic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year_Built")
                        .HasColumnType("int");

                    b.HasKey("IdNavio");

                    b.ToTable("VesselInfos");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.VesselTravel", b =>
                {
                    b.Property<int>("IdTravel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DestinationIdHarbor")
                        .HasColumnType("int");

                    b.Property<int>("IdDestination")
                        .HasColumnType("int");

                    b.Property<int>("IdOrigin")
                        .HasColumnType("int");

                    b.Property<int>("IdVessel")
                        .HasColumnType("int");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OriginIdHarbor")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VesselIdNavio")
                        .HasColumnType("int");

                    b.HasKey("IdTravel");

                    b.HasIndex("DestinationIdHarbor");

                    b.HasIndex("OriginIdHarbor");

                    b.HasIndex("VesselIdNavio");

                    b.ToTable("VesselTravels");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.TruckGeoPosition", b =>
                {
                    b.HasOne("GeoLocalizador.BE.Models.TruckInfo", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckIdTruck");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.TruckTravel", b =>
                {
                    b.HasOne("GeoLocalizador.BE.Models.GeoPosition", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationIdPosition");

                    b.HasOne("GeoLocalizador.BE.Models.GeoPosition", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginIdPosition");

                    b.HasOne("GeoLocalizador.BE.Models.TruckInfo", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckIdTruck");

                    b.Navigation("Destination");

                    b.Navigation("Origin");

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.VesselGeoPosition", b =>
                {
                    b.HasOne("GeoLocalizador.BE.Models.VesselInfo", "VesselInfo")
                        .WithMany()
                        .HasForeignKey("VesselInfoIdNavio");

                    b.Navigation("VesselInfo");
                });

            modelBuilder.Entity("GeoLocalizador.BE.Models.VesselTravel", b =>
                {
                    b.HasOne("GeoLocalizador.BE.Models.Harbor", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationIdHarbor");

                    b.HasOne("GeoLocalizador.BE.Models.Harbor", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginIdHarbor");

                    b.HasOne("GeoLocalizador.BE.Models.VesselInfo", "Vessel")
                        .WithMany()
                        .HasForeignKey("VesselIdNavio");

                    b.Navigation("Destination");

                    b.Navigation("Origin");

                    b.Navigation("Vessel");
                });
#pragma warning restore 612, 618
        }
    }
}
