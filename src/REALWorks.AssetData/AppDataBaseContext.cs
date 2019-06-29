using Microsoft.EntityFrameworkCore;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetCore.ValueObjects;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using REALWorks.AssetData.Configuration;
using static REALWorks.AssetCore.Entities.FeePayment;

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
        public virtual DbSet<OwnerAddress> OwnerAddress { get; set; }
        public virtual DbSet<ManagementContract> ManagementContract { get; set; }
        public virtual DbSet<OwnerProperty> OwnerProperty { get; set; }
        public virtual DbSet<FeePayment> FeePayment { get; set; }


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

            modelBuilder.Entity<FeePayment>(entity =>
            {
                entity.Property(e => e.ActualPaymentAmt).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Note).HasMaxLength(450);

                entity.Property(e => e.ScheduledPaymentAmt).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.FeePayment)
                    .HasForeignKey(d => d.ManagementContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeePayment_ManagementContract");

                entity.Property(e => e.PayMethod)
               .HasConversion(
                   v => v.ToString(),
                   v => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v));

                entity.Property(e => e.MangementFeeType)
               .HasConversion(
                   v => v.ToString(),
                   v => (FeeType)Enum.Parse(typeof(FeeType), v));
            });

            //modelBuilder.Entity<FeePayment>()
            //    .HasKey(c => c.Id);

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

            modelBuilder.Entity<PropertyOwner>().OwnsOne(
                a => a.Address,
                sa =>
                {
                    sa.ToTable("OwnerAddress");
                }
            );
        }


    }
}
