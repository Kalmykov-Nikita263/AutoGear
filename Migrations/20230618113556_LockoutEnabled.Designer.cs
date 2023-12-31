﻿// <auto-generated />
using System;
using AutoGear.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoGear.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230618113556_LockoutEnabled")]
    partial class LockoutEnabled
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoGear.Domain.Car", b =>
                {
                    b.Property<Guid>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Speed")
                        .HasColumnType("float");

                    b.HasKey("CarId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            CarId = new Guid("73b67445-c7c0-4ad9-ad51-a309e88995b5"),
                            CarName = "Мерседес",
                            Speed = 100.0
                        });
                });

            modelBuilder.Entity("AutoGear.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = "3568DAFB-5617-4B95-9618-5572274FC621",
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("AutoGear.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLockedOut")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "E3B1A7AA-88EF-41E0-89B9-3803B8B54760",
                            AccessFailedCount = 0,
                            Email = "wpfsucks@mail.ru",
                            IsLockedOut = false,
                            LockoutEnabled = true,
                            PasswordHash = "uiF2euSUr+WiFl3LMzjFMj6ZBwUONFQsQF1XXMMb9Sc=",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("AutoGear.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "E3B1A7AA-88EF-41E0-89B9-3803B8B54760",
                            RoleId = "3568DAFB-5617-4B95-9618-5572274FC621"
                        });
                });

            modelBuilder.Entity("AutoGear.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("AutoGear.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoGear.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
