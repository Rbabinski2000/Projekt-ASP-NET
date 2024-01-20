﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240120152717_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

            modelBuilder.Entity("Data.Entities.GuideEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("organization");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Grzegorz",
                            Pesel = "13424234123",
                            Surname = "Drewniak"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tomasz",
                            Pesel = "13424234567",
                            Surname = "Drewniak"
                        });
                });

            modelBuilder.Entity("Data.Entities.TravelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EndPlace")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GuideId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Participants")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("StartPlace")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GuideId");

                    b.ToTable("Travels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 1, 20, 16, 27, 17, 725, DateTimeKind.Local).AddTicks(4709),
                            EndDate = new DateTime(2012, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndPlace = "Kair",
                            GuideId = 1,
                            Name = "Niezapomniana Podróż-Kair",
                            Participants = "Kamil,Dawid,Michał",
                            StartDate = new DateTime(2012, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartPlace = "Warszawa"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 1, 20, 16, 27, 17, 725, DateTimeKind.Local).AddTicks(4759),
                            EndDate = new DateTime(2013, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndPlace = "Egipt",
                            GuideId = 2,
                            Name = "Niezapomniana Podróż-Egipt",
                            Participants = "Kamil,Dawid,Gabryś",
                            StartDate = new DateTime(2013, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartPlace = "Kraków"
                        });
                });

            modelBuilder.Entity("Data.Entities.GuideEntity", b =>
                {
                    b.OwnsOne("Data.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("GuideEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("GuideEntityId");

                            b1.ToTable("organization");

                            b1.WithOwner()
                                .HasForeignKey("GuideEntityId");

                            b1.HasData(
                                new
                                {
                                    GuideEntityId = 1,
                                    City = "Kraków",
                                    PostalCode = "31-150",
                                    Region = "małopolskie",
                                    Street = "Św. Filipa 17"
                                },
                                new
                                {
                                    GuideEntityId = 2,
                                    City = "Kraków",
                                    PostalCode = "31-150",
                                    Region = "małopolskie",
                                    Street = "Krowoderska 45/6"
                                });
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Data.Entities.TravelEntity", b =>
                {
                    b.HasOne("Data.Entities.GuideEntity", "Guide")
                        .WithMany("Travels")
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guide");
                });

            modelBuilder.Entity("Data.Entities.GuideEntity", b =>
                {
                    b.Navigation("Travels");
                });
#pragma warning restore 612, 618
        }
    }
}