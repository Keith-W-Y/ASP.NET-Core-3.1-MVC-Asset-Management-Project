using CPRG214.AssetTrack.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CPRG214.AssetTrack.Data
{
    public class AssetTrackContext : DbContext
    {
        public AssetTrackContext() : base() { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Change the connection string here for your home computer/lab computer
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = AssetTrack; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data created here
            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Computer" },
                new AssetType { Id = 2, Name = "Monitor" },
                new AssetType { Id = 3, Name = "Phone" }
                );


            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    Id = 1,
                    TagNumber = "Tag-B1-01",
                    AssetTypeId = 2,
                    Manufacturer = "Acer",
                    Model = "Model-B1-01",
                    Description = "Description-B1-01",
                    SerialNumber = "SN-B1-01"
                },
                new Asset
                {
                    Id = 2,
                    TagNumber = "Tag-A2-02",
                    AssetTypeId = 1,
                    Manufacturer = "HP",
                    Model = "Model-A2-02",
                    Description = "Description-A2-02",
                    SerialNumber = "SN-A2-02"
                },
                new Asset
                {
                    Id = 3,
                    TagNumber = "Tag-C3-03",
                    AssetTypeId = 3,
                    Manufacturer = "Cisco",
                    Model = "Model-C3-03",
                    Description = "Description-C3-03",
                    SerialNumber = "SN-C3-03"
                }
                );
        }
    }
}

