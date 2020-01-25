﻿// <auto-generated />
using System;
using GuestTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GuestTracker.Web.Migrations
{
    [DbContext(typeof(GuestDbContext))]
    partial class GuestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuestTracker.DAL.Models.Guest", b =>
                {
                    b.Property<Guid>("Guest_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuestAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurposeOfVisit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Signature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VisitDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WhomToSee")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guest_Id");

                    b.HasIndex("VisitDetailId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("GuestTracker.DAL.Models.VisitDetail", b =>
                {
                    b.Property<Guid>("Visit_Detail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GuestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfVisit")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Visit_Detail_Id");

                    b.ToTable("VisitDetails");
                });

            modelBuilder.Entity("GuestTracker.DAL.Models.Guest", b =>
                {
                    b.HasOne("GuestTracker.DAL.Models.VisitDetail", "VisitDetail")
                        .WithMany("Guests")
                        .HasForeignKey("VisitDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
