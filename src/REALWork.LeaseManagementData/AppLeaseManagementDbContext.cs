using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using static REALWork.LeaseManagementCore.Entities.Lease;
using static REALWork.LeaseManagementCore.Entities.RentPayment;
using static REALWork.LeaseManagementCore.Entities.ServiceRequest;

namespace REALWork.LeaseManagementData
{
    public class AppLeaseManagementDbContext : DbContext
    {
        public AppLeaseManagementDbContext()
        {
        }

        public AppLeaseManagementDbContext(DbContextOptions<AppLeaseManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<Lease> Lease { get; set; }
        public virtual DbSet<PropertyVisit> PropertyVisit { get; set; }
        public virtual DbSet<RentalProperty> RentalProperty { get; set; }
        public virtual DbSet<RentCoverage> RentCoverage { get; set; }
        public virtual DbSet<RentPayment> RentPayment { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<WorkOrder> WorkOrder { get; set; }
        public virtual DbSet<NewTenant> NewTenant { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<ServiceRequest> Request { get; set; }
        public virtual DbSet<ServiceRequestComment> Comment { get; set; }
        public virtual DbSet<PropertyInspection> Inspection { get; set; }

        public virtual DbSet<Basement> Basement { get; set; }
        public virtual DbSet<Entry> RentalEntry { get; set; }
        public virtual DbSet<DinningRoom> DinningRoom { get; set; }
        public virtual DbSet<Exterior> Exterior { get; set; }
        public virtual DbSet<GarageParkingArea> GarageParkingArea { get; set; }
        public virtual DbSet<KeyAndControl> KeyAndControl { get; set; }
        public virtual DbSet<Kitchen> Kitchen { get; set; }
        public virtual DbSet<LivingRoom> LivingRoom { get; set; }
        public virtual DbSet<MainBathroom> MainBathroom { get; set; }
        public virtual DbSet<MasterBedroom> MasterBedroom { get; set; }
        public virtual DbSet<OtherBedroom> OtherBedroom { get; set; }
        public virtual DbSet<StairWayHallWay> StairWayHallWay { get; set; }
        public virtual DbSet<UtilityRoom> UtilityRoom { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=.\\;Database=REALMarketingTmp;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AppDbConnection2"].ConnectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Address>(entity =>
            //{
            //    entity.HasKey(e => e.RentalPropertyId);

            //    entity.Property(e => e.RentalPropertyId).ValueGeneratedNever();

            //    entity.HasOne(d => d.RentalProperty)
            //        .WithOne(p => p.Address)
            //        .HasForeignKey<Address>(d => d.RentalPropertyId);
            //});

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.Property(e => e.AddressCity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AddressCountry)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AddressStateProv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AddressStreetNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AddressZipPostCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactEmial)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ContactOthers).HasMaxLength(250);

                entity.Property(e => e.ContztTel)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsPropertyManager).HasColumnName("isPropertyManager");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Lease)
                    .WithMany(p => p.Agent)
                    .HasForeignKey(d => d.LeaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agent_Lease");
            });

            modelBuilder.Entity<Lease>(entity =>
            {
                entity.Property(e => e.DamageDepositAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LeaseAgreementDocUrl)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LeaseDesc).HasMaxLength(4000);

                entity.Property(e => e.LeaseTitle)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PetDepositAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RentAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RentDueOn)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.RentFrequency)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RentalProperty)
                    .WithMany(p => p.Lease)
                    .HasForeignKey(d => d.RentalPropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lease_RentalProperty");

                entity.HasMany(i => i.PropertyInspection) // newly added
                    .WithOne(l => l.Lease);

                entity.Property(e => e.Term)
               .HasConversion(
                   v => v.ToString(),
                   v => (LeaseTerm)Enum.Parse(typeof(LeaseTerm), v));
            });

            modelBuilder.Entity<Lease>().OwnsOne(
                a => a.RentCoverage,
                sa =>
                {
                    sa.ToTable("RentCoverage");
                }
            );

            modelBuilder.Entity<PropertyVisit>(entity =>
            {
                entity.Property(e => e.HoursSpent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MileageDriven).HasMaxLength(100);

                entity.Property(e => e.TimeSpent)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VisitEndTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VisitPurpose)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.VisitStartTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RentalProperty)
                    .WithMany(p => p.PropertyVisit)
                    .HasForeignKey(d => d.RentalPropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyVisit_RentalProperty");
            });

            modelBuilder.Entity<RentalProperty>(entity =>
            {
                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PropertyType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RentalProperty>().OwnsOne(
                a => a.Address,
                sa =>
                {
                    sa.ToTable("Address");
                }
            );

            //modelBuilder.Entity<RentCoverage>(entity =>
            //{
            //    entity.HasKey(e => e.LeaseId);

            //    entity.Property(e => e.LeaseId).ValueGeneratedNever();

            //    entity.Property(e => e.Other).HasMaxLength(50);

            //    entity.Property(e => e.ParkingStall).HasDefaultValueSql("((1))");

            //    entity.HasOne(d => d.Lease)
            //        .WithOne(p => p.RentCoverage)
            //        .HasForeignKey<RentCoverage>(d => d.LeaseId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_RentCoverage_Lease");
            //});

            modelBuilder.Entity<RentPayment>(entity =>
            {
                entity.Property(e => e.ActualPaymentAmt).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Note).HasMaxLength(450);

                entity.Property(e => e.ScheduledPaymentAmt).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Lease)
                    .WithMany(p => p.RentPayment)
                    .HasForeignKey(d => d.LeaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentPayment_Lease");

                entity.Property(e => e.PayMethod)
               .HasConversion(
                   v => v.ToString(),
                   v => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v));
            });


            modelBuilder.Entity<ServiceRequest>(entity =>
            {
                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.RequestDetails).HasMaxLength(1000);

                entity.HasOne(d => d.Lease)
                .WithMany(r => r.ServiceRequest)
                .HasForeignKey( d => d.LeaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServieRequest_Lease");

                entity.Property(e => e.Urgent)
                .HasConversion(
                    v => v.ToString(),
                    v => (UrgencyLevel)Enum.Parse(typeof(UrgencyLevel), v));

                entity.Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (RequestStatus)Enum.Parse(typeof(RequestStatus), v));

            });


            modelBuilder.Entity<ServiceRequestComment>(entity =>
            {
                entity.HasOne(d => d.ServiceRequest)
                .WithMany(c => c.ServiceRequestComment)
                .HasForeignKey(d => d.ServiceRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceRequestComment_ServiceRequest");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ContactOthers)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ContactTelephone1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactTelephone2).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserAvartaImgUrl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('default')");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('tba')");

                entity.HasOne(d => d.Lease)
                    .WithMany(p => p.Tenant)
                    .HasForeignKey(d => d.LeaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tenant_Lease");
            });

            modelBuilder.Entity<NewTenant>(entity =>
            {
                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ContactOthers)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ContactTelephone1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactTelephone2).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });


            modelBuilder.Entity<PropertyInspection>(entity =>
            {
                entity.HasOne(l => l.Lease)
                    .WithMany(i => i.PropertyInspection)
                    .HasForeignKey( l => l.LeaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriopertyInspection_Lease");                

            });


            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.BasementCondition,
                sa =>
                {
                    sa.ToTable("BasementCondition");
                }

            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.EntryCondition,
                sa =>
                {
                    sa.ToTable("EntryCondition");
                }
            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.ExteriorCondition,
                sa =>
                {
                    sa.ToTable("ExteriorCondition");
                }
            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.LivingRoomCondition,
                sa =>
                {
                    sa.ToTable("LivingRoomCondition");
                }
            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.MasterBedroomCondition,
                sa =>
                {
                    sa.ToTable("MasterBedroomCondition");
                }
            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.OtherBedroomCondition,
                sa =>
                {
                    sa.ToTable("OtherBedroomCondition");
                }
            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.MainBathroomCondition,
                sa =>
                {
                    sa.ToTable("MainBathroomCondition");
                }
            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.KitchenCondition,
                sa =>
                {
                    sa.ToTable("KitchenCondition");
                }
            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.UtilityRoomCondition,
                sa =>
                {
                    sa.ToTable("UtilityRoomCondition");
                }
            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.GarageParkingAreaCondition,
                sa =>
                {
                    sa.ToTable("GarageParkingAreaCondition");
                }
            );



            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.StairWayHallWayCondition,
                sa =>
                {
                    sa.ToTable("StairWayHallWayCondition");
                }
            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.StorageCondition,
                sa =>
                {
                    sa.ToTable("StorageCondition");
                }
            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.DinningRoomCondition,
                sa =>
                {
                    sa.ToTable("DinningRoomCondition");
                }
            );

            modelBuilder.Entity<PropertyInspection>().OwnsOne(
                a => a.KeyAndControlCondition,
                sa =>
                {
                    sa.ToTable("KeyAndControlCondition");
                }
            );




            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserAvartaImgUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorBusinessName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.VendorContactEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VendorContactOthers)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VendorContactTelephone1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VendorDesc)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.VendorSpecialty)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                //entity.Property(e => e.InvoiceDocUrl)
                //    .HasMaxLength(150)
                //    .IsUnicode(false);

                entity.Property(e => e.Note).HasMaxLength(550);

                //entity.Property(e => e.PaymentMethod)
                //    .HasMaxLength(50)
                //    .IsUnicode(false);

                entity.Property(e => e.WorkOrderCategory)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkOrderDetails)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.WorkOrderName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkOrderStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkOrderType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RentalProperty)
                    .WithMany(p => p.WorkOrder)
                    .HasForeignKey(d => d.RentalPropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkOrder_RentalProperty");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.WorkOrder)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkOrder_Vendor");

            });

            //modelBuilder.Entity<WorkOrder>().OwnsOne(
            //    a => a.Invoice,
            //    sa =>
            //    {
            //        sa.ToTable("Invoice");
            //    }
            //);
        }



    }
}
