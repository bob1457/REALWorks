using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using REALWorks.AssetServer.Models;

namespace REALWorks.AssetServer.Data
{
    public partial class REALAssetContext : DbContext
    {
        public REALAssetContext()
        {
        }

        public REALAssetContext(DbContextOptions<REALAssetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Community> Community { get; set; }
        public virtual DbSet<Furnishing> Furnishing { get; set; }
        public virtual DbSet<OwnerProperty> OwnerProperty { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyAddress> PropertyAddress { get; set; }
        public virtual DbSet<PropertyFacility> PropertyFacility { get; set; }
        public virtual DbSet<PropertyFeature> PropertyFeature { get; set; }
        public virtual DbSet<PropertyImg> PropertyImg { get; set; }
        public virtual DbSet<PropertyOwner> PropertyOwner { get; set; }
        public virtual DbSet<PropertyType> PropertyType { get; set; }
        public virtual DbSet<RentalStatus> RentalStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=REALAsset;UID=real;PWD=1234567;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Community>(entity =>
            {
                entity.Property(e => e.CommunityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.HasOne(d => d.PropertyAddress)
                    .WithMany(p => p.Community)
                    .HasForeignKey(d => d.PropertyAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Community_PropertyAddress");
            });

            modelBuilder.Entity<Furnishing>(entity =>
            {
                entity.Property(e => e.FurnishingCategory)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FurnishingConditions).HasMaxLength(350);

                entity.Property(e => e.FurnishingItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(650);
            });

            modelBuilder.Entity<OwnerProperty>(entity =>
            {
                entity.HasKey(e => new { e.PropertyId, e.PropertyOwnerId });

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.OwnerProperty)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerProperty_Property");

                entity.HasOne(d => d.PropertyOwner)
                    .WithMany(p => p.OwnerProperty)
                    .HasForeignKey(d => d.PropertyOwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnerProperty_PropertyOwner");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.FurnishingId).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.PropertyAddress)
                    .WithMany(p => p.Property)
                    .HasForeignKey(d => d.PropertyAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_PropertyAddress");

                entity.HasOne(d => d.PropertyFacility)
                    .WithMany(p => p.Property)
                    .HasForeignKey(d => d.PropertyFacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_PropertyFacility");

                entity.HasOne(d => d.PropertyFeature)
                    .WithMany(p => p.Property)
                    .HasForeignKey(d => d.PropertyFeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_PropertyFeature");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.Property)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_PropertyType");

                entity.HasOne(d => d.RentalStatus)
                    .WithMany(p => p.Property)
                    .HasForeignKey(d => d.RentalStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_RentalStatus");
            });

            modelBuilder.Entity<PropertyAddress>(entity =>
            {
                entity.Property(e => e.GpslatitudeValue)
                    .HasColumnName("GPSLatitudeValue")
                    .HasMaxLength(50);

                entity.Property(e => e.GpslongitudeValue)
                    .HasColumnName("GPSLongitudeValue")
                    .HasMaxLength(50);

                entity.Property(e => e.PropertyCity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PropertyCountry)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PropertyNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PropertyStateProvince)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PropertyStreet)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PropertySuiteNumber).HasMaxLength(50);

                entity.Property(e => e.PropertyZipPostCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PropertyFacility>(entity =>
            {
                entity.Property(e => e.BlindsCurtain)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Dishwasher)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FireAlarmSystem)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Laundry)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Notes).HasMaxLength(400);

                entity.Property(e => e.Others).HasMaxLength(350);

                entity.Property(e => e.Refrigerator)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Stove)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Tvinternet).HasColumnName("TVInternet");
            });

            modelBuilder.Entity<PropertyFeature>(entity =>
            {
                entity.Property(e => e.Notes).HasMaxLength(400);
            });

            modelBuilder.Entity<PropertyImg>(entity =>
            {
                entity.Property(e => e.PropertyImgCaption).HasMaxLength(350);

                entity.Property(e => e.PropertyImgTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.PropertyImg)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyImg_Property");
            });

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

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(350);

                entity.Property(e => e.PropertyType1)
                    .IsRequired()
                    .HasColumnName("PropertyType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RentalStatus>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(350);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
