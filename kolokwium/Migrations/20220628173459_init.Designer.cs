﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolokwium.Context;

#nullable disable

namespace kolokwium.Migrations
{
    [DbContext(typeof(OrganizationDbContext))]
    [Migration("20220628173459_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("kolokwium.Model.File", b =>
                {
                    b.Property<int>("FileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileID"), 1L, 1);

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("FileID", "TeamID");

                    b.HasIndex("TeamID");

                    b.ToTable("File");

                    b.HasData(
                        new
                        {
                            FileID = 1,
                            TeamID = 1,
                            Extension = ".txt",
                            Name = "wynik",
                            Size = 3
                        },
                        new
                        {
                            FileID = 2,
                            TeamID = 1,
                            Extension = ".docx",
                            Name = "pismo",
                            Size = 10
                        },
                        new
                        {
                            FileID = 3,
                            TeamID = 2,
                            Extension = ".rar",
                            Name = "wniosek",
                            Size = 20
                        });
                });

            modelBuilder.Entity("kolokwium.Model.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MemberID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            Name = "Jan",
                            Nickname = "Kowal",
                            OrganizationID = 1,
                            Surname = "Kowalski"
                        },
                        new
                        {
                            MemberID = 2,
                            Name = "Jakub",
                            OrganizationID = 2,
                            Surname = "Nowak"
                        },
                        new
                        {
                            MemberID = 3,
                            Name = "Sławomir",
                            Nickname = "Skrót",
                            OrganizationID = 2,
                            Surname = "XYZ"
                        });
                });

            modelBuilder.Entity("kolokwium.Model.Membership", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MemberID1")
                        .HasColumnType("int");

                    b.Property<int?>("TeamID1")
                        .HasColumnType("int");

                    b.HasKey("MemberID", "TeamID");

                    b.HasIndex("MemberID1");

                    b.HasIndex("TeamID");

                    b.HasIndex("TeamID1");

                    b.ToTable("Membership");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            TeamID = 1,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MemberID = 2,
                            TeamID = 3,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MemberID = 3,
                            TeamID = 3,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("kolokwium.Model.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationID"), 1L, 1);

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OrganizationID");

                    b.ToTable("Organization");

                    b.HasData(
                        new
                        {
                            OrganizationID = 1,
                            Domain = "Kolory",
                            Name = "Kolorowi"
                        },
                        new
                        {
                            OrganizationID = 2,
                            Domain = "Jednostki",
                            Name = "Jednostkowi"
                        });
                });

            modelBuilder.Entity("kolokwium.Model.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.HasKey("TeamID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Team");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            Name = "Niebiescy",
                            OrganizationID = 1
                        },
                        new
                        {
                            TeamID = 2,
                            Name = "Zieloni",
                            OrganizationID = 1
                        },
                        new
                        {
                            TeamID = 3,
                            Description = "Ten zespół jest czerwony",
                            Name = "Czerwoni",
                            OrganizationID = 2
                        });
                });

            modelBuilder.Entity("kolokwium.Model.File", b =>
                {
                    b.HasOne("kolokwium.Model.Team", "Team")
                        .WithMany("Files")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("kolokwium.Model.Member", b =>
                {
                    b.HasOne("kolokwium.Model.Organization", "Organization")
                        .WithMany("Members")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("kolokwium.Model.Membership", b =>
                {
                    b.HasOne("kolokwium.Model.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("kolokwium.Model.Member", null)
                        .WithMany("Memberships")
                        .HasForeignKey("MemberID1");

                    b.HasOne("kolokwium.Model.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("kolokwium.Model.Team", null)
                        .WithMany("Memberships")
                        .HasForeignKey("TeamID1");

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("kolokwium.Model.Team", b =>
                {
                    b.HasOne("kolokwium.Model.Organization", "Organization")
                        .WithMany("Teams")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("kolokwium.Model.Member", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("kolokwium.Model.Organization", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("kolokwium.Model.Team", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
