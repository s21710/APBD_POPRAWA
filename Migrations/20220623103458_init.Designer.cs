﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using probne_kolokwium.Entities;

namespace probne_kolokwium.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220623103458_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("probne_kolokwium.Entities.Models.File", b =>
                {
                    b.Property<int>("FileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("FileID");

                    b.HasIndex("TeamID");

                    b.ToTable("File");

                    b.HasData(
                        new
                        {
                            FileID = 1,
                            FileExtension = "png",
                            FileName = "asdsda",
                            FileSize = 2,
                            TeamID = 1
                        });
                });

            modelBuilder.Entity("probne_kolokwium.Entities.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MemberNickName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MemberSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.HasKey("MemberID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            MemberName = "Piter",
                            MemberNickName = "glizdogon",
                            MemberSurname = "Pettigrew",
                            OrganizationID = 1
                        });
                });

            modelBuilder.Entity("probne_kolokwium.Entities.Models.Membership", b =>
                {
                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MembershipDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberID", "TeamID");

                    b.HasIndex("TeamID");

                    b.ToTable("Membership");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            TeamID = 1,
                            MembershipDate = new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("probne_kolokwium.Entities.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrganizationDomain")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("OrganizationID");

                    b.ToTable("Organization");

                    b.HasData(
                        new
                        {
                            OrganizationID = 1,
                            OrganizationDomain = "Audit",
                            OrganizationName = "PwC"
                        },
                        new
                        {
                            OrganizationID = 2,
                            OrganizationDomain = "Audit",
                            OrganizationName = "Deloitte"
                        });
                });

            modelBuilder.Entity("probne_kolokwium.Entities.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("TeamDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeamID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Team");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            OrganizationID = 1,
                            TeamDescription = "opis",
                            TeamName = "teamnazwa"
                        });
                });

            modelBuilder.Entity("probne_kolokwium.Entities.Models.File", b =>
                {
                    b.HasOne("probne_kolokwium.Entities.Models.Team", "Team")
                        .WithMany("Files")
                        .HasForeignKey("TeamID")
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("probne_kolokwium.Entities.Models.Member", b =>
                {
                    b.HasOne("probne_kolokwium.Entities.Models.Organization", "Organization")
                        .WithMany("Members")
                        .HasForeignKey("OrganizationID")
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("probne_kolokwium.Entities.Models.Membership", b =>
                {
                    b.HasOne("probne_kolokwium.Entities.Models.Member", "Member")
                        .WithMany("Memberships")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("probne_kolokwium.Entities.Models.Team", "Team")
                        .WithMany("Memberships")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("probne_kolokwium.Entities.Models.Team", b =>
                {
                    b.HasOne("probne_kolokwium.Entities.Models.Organization", "Organization")
                        .WithMany("Teams")
                        .HasForeignKey("OrganizationID")
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("probne_kolokwium.Entities.Models.Member", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("probne_kolokwium.Entities.Models.Organization", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("probne_kolokwium.Entities.Models.Team", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
