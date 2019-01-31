using Microsoft.EntityFrameworkCore;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetCore.ValueObjects;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using REALWorks.AssetData.Configuration;

namespace REALWorks.AssetData
{
    public class AppDataBaseContext: DbContext
    {
        public AppDataBaseContext()
        {
        }

        public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Database Tables
        /// </summary>
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyAddress> PropertyAddress { get; set; }
        public virtual DbSet<PropertyImg> PropertyImg { get; set; }
        public virtual DbSet<PropertyOwner> PropertyOwner { get; set; }
        public virtual DbSet<ManagementContract> ManagementContract { get; set; }
        public virtual DbSet<OwnerProperty> OwnerProperty { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AppDbConnection2"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PropertyConfig());
            modelBuilder.ApplyConfiguration(new OwnerConfig());
            modelBuilder.ApplyConfiguration(new OwnerPropertyConfig());
            modelBuilder.ApplyConfiguration(new ManagementCaontactConfig());



            modelBuilder.Entity<Property>().OwnsOne(
                a => a.Address,
                sa =>
                {                    
                    sa.ToTable("PropertyAddress");
                }
            );

            modelBuilder.Entity<Property>().OwnsOne(
                a => a.Feature,
                sa =>
                {
                    sa.ToTable("PropertyFeature");
                }
            );

            modelBuilder.Entity<Property>().OwnsOne(
                a => a.Facility,
                sa =>
                {
                    sa.ToTable("PropertyFacility");
                }
            );


        }


    }
}
