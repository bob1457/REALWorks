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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=REALAsset;UID=real;PWD=1234567;");
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AppDbConnection2"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //**********************************************
            // Entity for mapping DDD entities
            //**********************************************

            modelBuilder.ApplyConfiguration(new PropertyConfig());
            modelBuilder.ApplyConfiguration(new OwnerConfig());
            modelBuilder.ApplyConfiguration(new OwnerPropertyConfig());


            /*
            modelBuilder.Entity<Property>(entity =>
            {
                //entity.Property(e => e.FurnishingId).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PropertyDesc).HasMaxLength(250);

                entity.Property(e => e.PropertyLogoImgUrl).HasMaxLength(100);

                entity.Property(e => e.PropertyManagerId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PropertyVideoUrl).HasMaxLength(100);

                entity.Property(e => e.StrataCouncilId).HasDefaultValueSql("((0))");

                //entity.HasOne(d => d.PropertyAddress)
                //    .WithMany(p => p.Property)
                //    .HasForeignKey(d => d.PropertyAddressId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Property_PropertyAddress");

                //entity.HasOne(d => d.PropertyFacility)
                //    .WithMany(p => p.Property)
                //    .HasForeignKey(d => d.PropertyFacilityId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Property_PropertyFacility");

                //entity.HasOne(d => d.PropertyFeature)
                //    .WithMany(p => p.Property)
                //    .HasForeignKey(d => d.PropertyFeatureId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Property_PropertyFeature");

                //entity.HasOne(d => d.PropertyType)
                //    .WithMany(p => p.Property)
                //    .HasForeignKey(d => d.PropertyTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Property_PropertyType");

                //entity.HasOne(d => d.RentalStatus)
                //    .WithMany(p => p.Property)
                //    .HasForeignKey(d => d.RentalStatusId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Property_RentalStatus");
            });
*/

            //**********************************************
            // Owned Entity for mapping DDD value objects
            //**********************************************

            //modelBuilder.Entity<Property>().OwnsOne(typeof(PropertyAddress), "Address"); // this operation will put the onwed entity in the principal entity (one table)

            //The following mapping will put the owned entity in a separate table (with a foreign key pointing to the principal entity
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


            /*
            modelBuilder.Entity<PropertyOwner>(entity =>
            {
                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactTelephone1)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ContactTelephone2).HasMaxLength(25);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserAvartaImgUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('default')");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('tba')");
            });
*/

        }


    }
}
