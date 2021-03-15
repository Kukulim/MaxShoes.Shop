﻿// <auto-generated />
using System;
using MaxShoes.Shop.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MaxShoes.Shop.Identity.Migrations
{
    [DbContext(typeof(ApplicationIdentityDbContext))]
    [Migration("20210315095939_addusers")]
    partial class addusers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MaxShoes.Shop.Domain.Entities.Notification", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Response")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("MaxShoes.Shop.Identity.Models.UserModels.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "37846734-172e-4149-8cec-6f43d1eb3f60",
                            Email = "Employee1@test.pl",
                            IsEmailConfirmed = true,
                            Password = "$2a$11$SK0eDWBrnPV/CTU5Oa6bm.hPzoewvHXnCFqiWhNQunUvh93oRXPLC",
                            Role = "Employee",
                            UserName = "Employee1"
                        },
                        new
                        {
                            Id = "37846734-172e-4149-8cec-6f43d1eb3f61",
                            Email = "Employee2@test.pl",
                            IsEmailConfirmed = true,
                            Password = "$2a$11$QwwGS16U8T5b4pgrRp75HO4O8MJGkNgJ9C3OtyORhVqr4ex4K7fCa",
                            Role = "Employee",
                            UserName = "Employee2"
                        });
                });

            modelBuilder.Entity("MaxShoes.Shop.Domain.Entities.Notification", b =>
                {
                    b.HasOne("MaxShoes.Shop.Identity.Models.UserModels.User", null)
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MaxShoes.Shop.Identity.Models.UserModels.User", b =>
                {
                    b.OwnsOne("MaxShoes.Shop.Application.Models.UserModels.Contact", "Contact", b1 =>
                        {
                            b1.Property<string>("UserId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("ApartmentNumber")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FirstName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("HouseNumber")
                                .HasColumnType("int");

                            b1.Property<string>("Id")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PhoneNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                                    ApartmentNumber = 23,
                                    City = "Czestochowa",
                                    FirstName = "Piter",
                                    HouseNumber = 45,
                                    Id = "2c5e391a-b014-4b79-9102-7d80f554c5ce",
                                    LastName = "Blukacz",
                                    PhoneNumber = "666111222",
                                    State = "Polska",
                                    Street = "Zielona",
                                    ZipCode = "42-200"
                                },
                                new
                                {
                                    UserId = "37846734-172e-4149-8cec-6f43d1eb3f61",
                                    ApartmentNumber = 0,
                                    City = "Czestochowa",
                                    FirstName = "Jan",
                                    HouseNumber = 2,
                                    Id = "781357eb-df6d-4548-ae34-4f544bad96d1",
                                    LastName = "Oko",
                                    PhoneNumber = "666111223",
                                    State = "Polska",
                                    Street = "Liliowa",
                                    ZipCode = "42-202"
                                });
                        });

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("MaxShoes.Shop.Identity.Models.UserModels.User", b =>
                {
                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}