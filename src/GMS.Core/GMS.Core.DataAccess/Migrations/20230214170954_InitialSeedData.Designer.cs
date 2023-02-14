﻿// <auto-generated />
using System;
using GMS.Core.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GMS.Core.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230214170954_InitialSeedData")]
    partial class InitialSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GMS.Core.Core.Domain.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("FitnessClubId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("FitnessClubId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FitnessClubId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FitnessClubId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.FitnessClub", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Address")
                        .IsUnicode(false)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("character varying(4096)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("character varying(64)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FitnessClubs");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("character varying(1024)");

                    b.Property<Guid>("FitnessClubId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FitnessClubId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.TimeSlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("character varying(512)");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<Guid>("FitnessClubId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("character varying(64)");

                    b.Property<Guid>("TrainerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AreaId")
                        .IsUnique();

                    b.HasIndex("DateTime")
                        .IsUnique();

                    b.HasIndex("FitnessClubId");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<Guid>("TimeSlotId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TimeSlotId")
                        .IsUnique();

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.Area", b =>
                {
                    b.HasOne("GMS.Core.Core.Domain.FitnessClub", "FitnessClub")
                        .WithMany("Areas")
                        .HasForeignKey("FitnessClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FitnessClub");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.Contract", b =>
                {
                    b.HasOne("GMS.Core.Core.Domain.FitnessClub", "FitnessClub")
                        .WithMany("Contracts")
                        .HasForeignKey("FitnessClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GMS.Core.Core.Domain.Product", "Product")
                        .WithOne("Contract")
                        .HasForeignKey("GMS.Core.Core.Domain.Contract", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FitnessClub");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.Product", b =>
                {
                    b.HasOne("GMS.Core.Core.Domain.FitnessClub", "FitnessClub")
                        .WithMany("Products")
                        .HasForeignKey("FitnessClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FitnessClub");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.TimeSlot", b =>
                {
                    b.HasOne("GMS.Core.Core.Domain.Area", "Area")
                        .WithOne("TimeSlot")
                        .HasForeignKey("GMS.Core.Core.Domain.TimeSlot", "AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GMS.Core.Core.Domain.FitnessClub", "FitnessClub")
                        .WithMany("TimeSlots")
                        .HasForeignKey("FitnessClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("FitnessClub");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.Training", b =>
                {
                    b.HasOne("GMS.Core.Core.Domain.TimeSlot", "TimeSlot")
                        .WithOne("Training")
                        .HasForeignKey("GMS.Core.Core.Domain.Training", "TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeSlot");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.Area", b =>
                {
                    b.Navigation("TimeSlot")
                        .IsRequired();
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.FitnessClub", b =>
                {
                    b.Navigation("Areas");

                    b.Navigation("Contracts");

                    b.Navigation("Products");

                    b.Navigation("TimeSlots");
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.Product", b =>
                {
                    b.Navigation("Contract")
                        .IsRequired();
                });

            modelBuilder.Entity("GMS.Core.Core.Domain.TimeSlot", b =>
                {
                    b.Navigation("Training")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
