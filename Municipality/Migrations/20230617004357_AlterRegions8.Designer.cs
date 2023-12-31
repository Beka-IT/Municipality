﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Municipality.Data;

#nullable disable

namespace Municipality.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230617004357_AlterRegions8")]
    partial class AlterRegions8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Municipality.Entities.AgriculturalLand", b =>
                {
                    b.Property<int>("LandQueueNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AgricultureAreaId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Area")
                        .HasColumnType("REAL");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LandQueueNumber");

                    b.HasIndex("AgricultureAreaId");

                    b.ToTable("AgriculturalLands");
                });

            modelBuilder.Entity("Municipality.Entities.AgricultureArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Area")
                        .HasColumnType("REAL");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VillageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VillageId");

                    b.ToTable("AgricultureAreas");
                });

            modelBuilder.Entity("Municipality.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RegionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Municipality.Entities.Irrigation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AgriculturalLandId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Irrigations");
                });

            modelBuilder.Entity("Municipality.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Municipality.Entities.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CoastForAnHectare")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VillageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VillageId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("Municipality.Entities.User", b =>
                {
                    b.Property<string>("Pin")
                        .HasColumnType("TEXT");

                    b.Property<int?>("AgriculturalLandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VillageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Pin");

                    b.HasIndex("AgriculturalLandId")
                        .IsUnique();

                    b.HasIndex("VillageId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Municipality.Entities.Village", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DistrictId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Villages");
                });

            modelBuilder.Entity("Municipality.Entities.AgriculturalLand", b =>
                {
                    b.HasOne("Municipality.Entities.AgricultureArea", null)
                        .WithMany("AgriculturalLands")
                        .HasForeignKey("AgricultureAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Municipality.Entities.AgricultureArea", b =>
                {
                    b.HasOne("Municipality.Entities.Village", null)
                        .WithMany("AgricultureAreas")
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Municipality.Entities.District", b =>
                {
                    b.HasOne("Municipality.Entities.Region", null)
                        .WithMany("Districts")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Municipality.Entities.Irrigation", b =>
                {
                    b.HasOne("Municipality.Entities.Round", null)
                        .WithMany("Irrigations")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Municipality.Entities.Round", b =>
                {
                    b.HasOne("Municipality.Entities.Village", null)
                        .WithMany("Rounds")
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Municipality.Entities.User", b =>
                {
                    b.HasOne("Municipality.Entities.AgriculturalLand", null)
                        .WithOne("Owner")
                        .HasForeignKey("Municipality.Entities.User", "AgriculturalLandId");

                    b.HasOne("Municipality.Entities.Village", null)
                        .WithMany("Users")
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Municipality.Entities.Village", b =>
                {
                    b.HasOne("Municipality.Entities.District", null)
                        .WithMany("Villages")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Municipality.Entities.AgriculturalLand", b =>
                {
                    b.Navigation("Owner")
                        .IsRequired();
                });

            modelBuilder.Entity("Municipality.Entities.AgricultureArea", b =>
                {
                    b.Navigation("AgriculturalLands");
                });

            modelBuilder.Entity("Municipality.Entities.District", b =>
                {
                    b.Navigation("Villages");
                });

            modelBuilder.Entity("Municipality.Entities.Region", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("Municipality.Entities.Round", b =>
                {
                    b.Navigation("Irrigations");
                });

            modelBuilder.Entity("Municipality.Entities.Village", b =>
                {
                    b.Navigation("AgricultureAreas");

                    b.Navigation("Rounds");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
