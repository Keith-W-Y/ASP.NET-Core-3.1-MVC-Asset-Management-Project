﻿// <auto-generated />
using CPRG214.AssetTrack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CPRG214.AssetTrack.Data.Migrations
{
    [DbContext(typeof(AssetTrackContext))]
    partial class AssetTrackContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CPRG214.AssetTrack.Domain.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssetTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TagNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.ToTable("Asset");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssetTypeId = 2,
                            Description = "Description-B1-01",
                            Manufacturer = "Acer",
                            Model = "Model-B1-01",
                            SerialNumber = "SN-B1-01",
                            TagNumber = "Tag-B1-01"
                        },
                        new
                        {
                            Id = 2,
                            AssetTypeId = 1,
                            Description = "Description-A2-02",
                            Manufacturer = "HP",
                            Model = "Model-A2-02",
                            SerialNumber = "SN-A2-02",
                            TagNumber = "Tag-A2-02"
                        },
                        new
                        {
                            Id = 3,
                            AssetTypeId = 3,
                            Description = "Description-C3-03",
                            Manufacturer = "Cisco",
                            Model = "Model-C3-03",
                            SerialNumber = "SN-C3-03",
                            TagNumber = "Tag-C3-03"
                        });
                });

            modelBuilder.Entity("CPRG214.AssetTrack.Domain.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssetType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Computer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Phone"
                        });
                });

            modelBuilder.Entity("CPRG214.AssetTrack.Domain.Asset", b =>
                {
                    b.HasOne("CPRG214.AssetTrack.Domain.AssetType", "AssetType")
                        .WithMany("Asset")
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
