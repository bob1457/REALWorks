using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using static REALWorks.MarketingCore.Entities.OpenHouseViewer;
using static REALWorks.MarketingCore.Entities.RentalApplicant;
using static REALWorks.MarketingCore.Entities.RentalApplication;
using static REALWorks.MarketingCore.Entities.RentalProperty;

namespace REALWorks.MarketingData
{
    public class AppMarketingDbDataContext : DbContext
    {
        public AppMarketingDbDataContext()
        {
        }

        public AppMarketingDbDataContext(DbContextOptions<AppMarketingDbDataContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<RentalProperty> Property { get; set; }
        ////public virtual DbSet<Address> PropertyAddress { get; set; }
        //public virtual DbSet<PropertyImg> PropertyImage { get; set; }
        //public virtual DbSet<OpenHouse> OpenHouse { get; set; }
        //public virtual DbSet<OpenHouseViewer> OpenHouseViewer { get; set; }
        //public virtual DbSet<RentalApplicant> Applicant { get; set; }
        //public virtual DbSet<RentalReference> Reference { get; set; }
        //public virtual DbSet<RentalApplication> RentalApplication { get; set; }
        //public virtual DbSet<PropertyListing> PropertyListing { get; set; }
        ////public virtual DbSet<ListingContact> Contact { get; set; }

        //public virtual DbSet<ListingContact> ListingContact { get; set; }
        public virtual DbSet<GeoLocation> GeoLocation { get; set; }
        public virtual DbSet<OpenHouse> OpenHouse { get; set; }
        public virtual DbSet<OpenHouseViewer> OpenHouseViewer { get; set; }
        public virtual DbSet<OwnerAddress> PropertyOwnerAddress { get; set; }
        public virtual DbSet<RentalPropertyOwner> RentalPropertyOwner { get; set; }
        public virtual DbSet<PropertyImg> PropertyImg { get; set; }
        public virtual DbSet<PropertyListing> PropertyListing { get; set; }
        public virtual DbSet<RentalApplicant> RentalApplicant { get; set; }
        public virtual DbSet<RentalApplication> RentalApplication { get; set; }
        public virtual DbSet<RentalProperty> RentalProperty { get; set; }
        public virtual DbSet<RentalReference> RentalReference { get; set; }
        public virtual DbSet<RentalApplicantScoreCard> RentalApplicantScoreCard { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=.\\;Database=REALMarketingTmp;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AppDbConnection"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListingContact>(entity =>
            {
                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactOthers).HasMaxLength(50);

                entity.Property(e => e.ContactSMS)
                    .HasColumnName("ContactSMS")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactTel)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OpenHouse>(entity =>
            {
                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(350);

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RentalProperty)
                    .WithMany(p => p.OpenHouse)
                    .HasForeignKey(d => d.RentalPropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpenHouse_RentalProperty");
            });

            modelBuilder.Entity<GeoLocation>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(350);
            });

            modelBuilder.Entity<OpenHouseViewer>(entity =>
            {
                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactOthers).HasMaxLength(50);

                entity.Property(e => e.ContactSms)
                    .HasColumnName("ContactSMS")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactTel).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.RentalProperty)
                    .WithMany(p => p.OpenHouseViewer)
                    .HasForeignKey(d => d.OpenHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpenHouseViewer_OpenHouse");

                entity.Property(e => e.ContactType)
                .HasConversion(
                    v => v.ToString(),
                    v => (PreferredContact)Enum.Parse(typeof(PreferredContact), v));

            });

            //modelBuilder.Entity<PropertyAddress>(entity =>
            //{
            //    entity.HasKey(e => e.RentalPropertyId);

            //    entity.Property(e => e.RentalPropertyId).ValueGeneratedNever();
            //});

            modelBuilder.Entity<PropertyImg>(entity =>
            {
                entity.HasOne(d => d.RentalProperty)
                    .WithMany(p => p.PropertyImg)
                    .HasForeignKey(d => d.RentalPropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyImg_RentalProperty");
            });

            modelBuilder.Entity<PropertyListing>(entity =>
            {
                entity.Property(e => e.ListingDesc).IsRequired();

                entity.HasOne(d => d.RentalProperty)
                    .WithMany(p => p.PropertyListing)
                    .HasForeignKey(d => d.RentalPropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyListing_RentalProperty");
               
            });


            modelBuilder.Entity<PropertyListing>().OwnsOne(
                a => a.Contact,
                sa =>
                {
                    sa.ToTable("ListingContact");
                }
            );



            modelBuilder.Entity<RentalApplicant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactOthers).HasMaxLength(50);

                entity.Property(e => e.ContactSms)
                    .HasColumnName("ContactSMS")
                    .HasMaxLength(50);

                entity.Property(e => e.ContactTel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreditRating).HasMaxLength(5);

                entity.Property(e => e.EmpoyedStatus).HasMaxLength(20);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                //entity.Property(e => e.Status)
                //    .IsRequired()
                //    .HasMaxLength(50);

                //entity.HasOne(d => d.IdNavigation)
                //    .WithOne(p => p.RentalApplicant)
                //    .HasForeignKey<RentalApplicant>(d => d.Id)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_RentalApplicant_RentalApplication1");

                

                entity.Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (LegalStatus)Enum.Parse(typeof(LegalStatus), v));
            });


            modelBuilder.Entity<RentalApplicantScoreCard>(entity =>
            {
                entity.HasOne(a => a.Applicant)
                .WithOne(p => p.ApplicantScoreCard);            
            });


            modelBuilder.Entity<RentalApplication>(entity =>
            {
                entity.HasOne(d => d.RentalProperty)
                    .WithMany(p => p.RentalApplication)
                    .HasForeignKey(d => d.RentalPropertyId)
                    .HasConstraintName("FK_RentalApplication_RentalProperty");

                entity.Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (ApplicationStatus)Enum.Parse(typeof(ApplicationStatus), v));
            });

            modelBuilder.Entity<RentalProperty>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PropertyType)
                    .IsRequired()
                    .HasMaxLength(50);

                //entity.HasOne(d => d.IdNavigation)
                //    .WithOne(p => p.RentalProperty)
                //    .HasForeignKey<RentalProperty>(d => d.Id)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_RentalProperty_PropertyAddress");

                entity.Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (ListingStatus)Enum.Parse(typeof(ListingStatus), v));

            });

            modelBuilder.Entity<RentalProperty>().OwnsOne(
                a => a.Address,
                sa =>
                {
                    sa.ToTable("Address");
                }
            );

            //modelBuilder.Entity<RentalPropertyOwner>(entity =>
            //{
            //    entity.HasOne(d => d.RentalProperty)
            //        .WithOne(p => p.RentalPropertyOwner)
            //        .HasForeignKey(d => d.RentalPropertyId)
            //        .HasConstraintName("FK_RentalPropertyOwner_RentalProperty");
            //});

            modelBuilder.Entity<RentalPropertyOwner>(entity =>
            {
                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactOther).HasMaxLength(50);

                entity.Property(e => e.ContactTelephone).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.RentalProperty)
                    .WithMany(p => p.RentalPropertyOwner)
                    .HasForeignKey(d => d.RentalPropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentalPropertyOwner_RentalProperty");
            });

            modelBuilder.Entity<RentalPropertyOwner>().OwnsOne(
                a => a.OwnerAddress,
                sa =>
                {
                    sa.ToTable("OwnerAddress");
                }
            );

            modelBuilder.Entity<RentalReference>(entity =>
            {
                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactTel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RentalApplicant)
                    .WithMany(p => p.RentalReference)
                    .HasForeignKey(d => d.RentalApplicatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentalReference_RentalApplicant");
            });
        }

    }
}
