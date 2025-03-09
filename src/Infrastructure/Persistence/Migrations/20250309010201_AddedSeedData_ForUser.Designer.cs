﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250309010201_AddedSeedData_ForUser")]
    partial class AddedSeedData_ForUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.AppointmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("AppointmentDate");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint")
                        .HasColumnName("Status");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OperationClaimEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 3, 9, 4, 2, 1, 339, DateTimeKind.Local).AddTicks(6500),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 3, 9, 4, 2, 1, 339, DateTimeKind.Local).AddTicks(6520),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ServiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Services", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 3, 9, 4, 2, 1, 339, DateTimeKind.Local).AddTicks(9148),
                            Name = "Egzoz Gazı Ölçümü"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 3, 9, 4, 2, 1, 339, DateTimeKind.Local).AddTicks(9156),
                            Name = "Fren Test"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 3, 9, 4, 2, 1, 339, DateTimeKind.Local).AddTicks(9157),
                            Name = "Far Ayarı"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint")
                        .HasColumnName("Gender");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordSalt");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("PhoneNumber");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint")
                        .HasColumnName("Type");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 3, 9, 4, 2, 1, 340, DateTimeKind.Local).AddTicks(3411),
                            Email = "admin@admin.com",
                            FirstName = "Admin",
                            Gender = (byte)0,
                            IsActive = true,
                            LastName = "Admin",
                            PasswordHash = new byte[] { 125, 8, 131, 92, 88, 157, 255, 245, 142, 200, 177, 0, 27, 9, 250, 99, 58, 204, 252, 150, 85, 225, 202, 151, 138, 135, 241, 138, 58, 160, 159, 231, 39, 123, 193, 21, 7, 179, 114, 139, 51, 239, 144, 172, 157, 156, 156, 30, 111, 45, 14, 115, 186, 192, 97, 89, 31, 225, 169, 8, 188, 129, 63, 146 },
                            PasswordSalt = new byte[] { 241, 214, 235, 133, 185, 140, 20, 6, 37, 80, 72, 147, 8, 147, 118, 231, 163, 62, 210, 135, 142, 197, 89, 21, 235, 236, 182, 74, 131, 103, 87, 173, 251, 37, 60, 180, 49, 244, 120, 236, 141, 115, 233, 169, 182, 61, 86, 169, 135, 201, 47, 2, 158, 77, 70, 56, 199, 96, 156, 90, 201, 224, 125, 230, 50, 145, 37, 107, 128, 98, 61, 175, 141, 228, 140, 10, 188, 52, 36, 51, 66, 12, 61, 125, 100, 223, 255, 200, 39, 150, 193, 176, 170, 249, 235, 70, 123, 19, 54, 132, 160, 227, 121, 187, 174, 220, 149, 90, 195, 4, 117, 237, 176, 139, 151, 20, 5, 42, 144, 161, 248, 178, 230, 47, 252, 137, 77, 105 },
                            PhoneNumber = "1234567890",
                            Type = (byte)1
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserOperationClaimEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int")
                        .HasColumnName("OperationClaimId");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOperationClaims", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AppointmentEntity", b =>
                {
                    b.HasOne("Domain.Entities.ServiceEntity", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserOperationClaimEntity", b =>
                {
                    b.HasOne("Domain.Entities.OperationClaimEntity", "OperationClaim")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.OperationClaimEntity", b =>
                {
                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Domain.Entities.ServiceEntity", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("UserOperationClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
