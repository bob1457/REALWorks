﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REALWorks.MarketingData;

namespace REALWorks.MarketingData.Migrations
{
    [DbContext(typeof(AppMarketingDbDataContext))]
    [Migration("20190719224823_update19")]
    partial class update19
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.OpenHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Notes")
                        .HasMaxLength(350);

                    b.Property<DateTime>("OpenhouseDate");

                    b.Property<int>("RentalPropertyId");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("RentalPropertyId");

                    b.ToTable("OpenHouse");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.OpenHouseViewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(50);

                    b.Property<string>("ContactOthers")
                        .HasMaxLength(50);

                    b.Property<string>("ContactSms")
                        .HasColumnName("ContactSMS")
                        .HasMaxLength(50);

                    b.Property<string>("ContactTel")
                        .HasMaxLength(50);

                    b.Property<string>("ContactType")
                        .IsRequired();

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Modified");

                    b.Property<int?>("NumberOfPeople");

                    b.Property<int>("OpenHouseId");

                    b.HasKey("Id");

                    b.HasIndex("OpenHouseId");

                    b.ToTable("OpenHouseViewer");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.PropertyImg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("PropertyImgTitle");

                    b.Property<string>("PropertyImgUrl");

                    b.Property<int>("RentalPropertyId");

                    b.HasKey("Id");

                    b.HasIndex("RentalPropertyId");

                    b.ToTable("PropertyImg");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.PropertyListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ListingDesc")
                        .IsRequired();

                    b.Property<DateTime>("Modified");

                    b.Property<decimal>("MonthlyRent");

                    b.Property<string>("Note");

                    b.Property<int>("RentalPropertyId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("RentalPropertyId");

                    b.ToTable("PropertyListing");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalApplicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnnualIncome");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ContactOthers")
                        .HasMaxLength(50);

                    b.Property<string>("ContactSms")
                        .HasColumnName("ContactSMS")
                        .HasMaxLength(50);

                    b.Property<string>("ContactTel")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreditRating")
                        .HasMaxLength(5);

                    b.Property<string>("EmpoyedStatus")
                        .HasMaxLength(20);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Modified");

                    b.Property<int>("NumberOfOccupant");

                    b.Property<string>("ReasonToMove");

                    b.Property<int>("RentalApplicationId");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<bool?>("WithChildren");

                    b.Property<bool>("WithCoApplicant");

                    b.HasKey("Id");

                    b.HasIndex("RentalApplicationId")
                        .IsUnique();

                    b.ToTable("RentalApplicant");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalApplicantScoreCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Notes");

                    b.Property<int>("RentalApplicantId");

                    b.HasKey("Id");

                    b.HasIndex("RentalApplicantId")
                        .IsUnique();

                    b.ToTable("RentalApplicantScoreCard");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Notes");

                    b.Property<int>("RentalPropertyId");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RentalPropertyId");

                    b.ToTable("RentalApplication");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsBasementSuite");

                    b.Property<bool>("IsShared");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Notes")
                        .HasMaxLength(450);

                    b.Property<int>("NumberOfBathrooms");

                    b.Property<int>("NumberOfBedrooms");

                    b.Property<int>("NumberOfLayers");

                    b.Property<int>("NumberOfParking");

                    b.Property<int>("OriginalId");

                    b.Property<string>("PmUserName");

                    b.Property<int>("PropertyBuildYear");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TotalLivingArea");

                    b.HasKey("Id");

                    b.ToTable("RentalProperty");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalPropertyOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(50);

                    b.Property<string>("ContactOther")
                        .HasMaxLength(50);

                    b.Property<string>("ContactTelephone")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Modified");

                    b.Property<int>("RentalPropertyId");

                    b.HasKey("Id");

                    b.HasIndex("RentalPropertyId");

                    b.ToTable("RentalPropertyOwner");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalReference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ContactTel")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("RentalApplicatId");

                    b.Property<int>("Type")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("RentalApplicatId");

                    b.ToTable("RentalReference");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.OpenHouse", b =>
                {
                    b.HasOne("REALWorks.MarketingCore.Entities.RentalProperty", "RentalProperty")
                        .WithMany("OpenHouse")
                        .HasForeignKey("RentalPropertyId")
                        .HasConstraintName("FK_OpenHouse_RentalProperty");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.OpenHouseViewer", b =>
                {
                    b.HasOne("REALWorks.MarketingCore.Entities.OpenHouse", "RentalProperty")
                        .WithMany("OpenHouseViewer")
                        .HasForeignKey("OpenHouseId")
                        .HasConstraintName("FK_OpenHouseViewer_OpenHouse");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.PropertyImg", b =>
                {
                    b.HasOne("REALWorks.MarketingCore.Entities.RentalProperty", "RentalProperty")
                        .WithMany("PropertyImg")
                        .HasForeignKey("RentalPropertyId")
                        .HasConstraintName("FK_PropertyImg_RentalProperty");
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.PropertyListing", b =>
                {
                    b.HasOne("REALWorks.MarketingCore.Entities.RentalProperty", "RentalProperty")
                        .WithMany("PropertyListing")
                        .HasForeignKey("RentalPropertyId")
                        .HasConstraintName("FK_PropertyListing_RentalProperty");

                    b.OwnsOne("REALWorks.MarketingCore.ValueObjects.ListingContact", "Contact", b1 =>
                        {
                            b1.Property<int>("PropertyListingId");

                            b1.Property<string>("ContactEmail")
                                .IsRequired()
                                .HasMaxLength(50);

                            b1.Property<string>("ContactName")
                                .IsRequired()
                                .HasMaxLength(50);

                            b1.Property<string>("ContactOthers")
                                .HasMaxLength(50);

                            b1.Property<string>("ContactSMS")
                                .HasColumnName("ContactSMS")
                                .HasMaxLength(50);

                            b1.Property<string>("ContactTel")
                                .IsRequired()
                                .HasMaxLength(50);

                            b1.HasKey("PropertyListingId");

                            b1.ToTable("ListingContact");

                            b1.HasOne("REALWorks.MarketingCore.Entities.PropertyListing")
                                .WithOne("Contact")
                                .HasForeignKey("REALWorks.MarketingCore.ValueObjects.ListingContact", "PropertyListingId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalApplicant", b =>
                {
                    b.HasOne("REALWorks.MarketingCore.Entities.RentalApplication", "RentalApplication")
                        .WithOne("RentalApplicant")
                        .HasForeignKey("REALWorks.MarketingCore.Entities.RentalApplicant", "RentalApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalApplicantScoreCard", b =>
                {
                    b.HasOne("REALWorks.MarketingCore.Entities.RentalApplicant", "Applicant")
                        .WithOne("ApplicantScoreCard")
                        .HasForeignKey("REALWorks.MarketingCore.Entities.RentalApplicantScoreCard", "RentalApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalApplication", b =>
                {
                    b.HasOne("REALWorks.MarketingCore.Entities.RentalProperty", "RentalProperty")
                        .WithMany("RentalApplication")
                        .HasForeignKey("RentalPropertyId")
                        .HasConstraintName("FK_RentalApplication_RentalProperty")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalProperty", b =>
                {
                    b.OwnsOne("REALWorks.MarketingCore.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("RentalPropertyId");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("StateProvince");

                            b1.Property<string>("StreetNum");

                            b1.Property<string>("ZipPostCode");

                            b1.HasKey("RentalPropertyId");

                            b1.ToTable("Address");

                            b1.HasOne("REALWorks.MarketingCore.Entities.RentalProperty")
                                .WithOne("Address")
                                .HasForeignKey("REALWorks.MarketingCore.ValueObjects.Address", "RentalPropertyId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalPropertyOwner", b =>
                {
                    b.HasOne("REALWorks.MarketingCore.Entities.RentalProperty", "RentalProperty")
                        .WithMany("RentalPropertyOwner")
                        .HasForeignKey("RentalPropertyId")
                        .HasConstraintName("FK_RentalPropertyOwner_RentalProperty");

                    b.OwnsOne("REALWorks.MarketingCore.ValueObjects.OwnerAddress", "OwnerAddress", b1 =>
                        {
                            b1.Property<int>("RentalPropertyOwnerId");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("StateProvince");

                            b1.Property<string>("StreetNumber");

                            b1.Property<string>("ZipPostCode");

                            b1.HasKey("RentalPropertyOwnerId");

                            b1.ToTable("OwnerAddress");

                            b1.HasOne("REALWorks.MarketingCore.Entities.RentalPropertyOwner")
                                .WithOne("OwnerAddress")
                                .HasForeignKey("REALWorks.MarketingCore.ValueObjects.OwnerAddress", "RentalPropertyOwnerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("REALWorks.MarketingCore.Entities.RentalReference", b =>
                {
                    b.HasOne("REALWorks.MarketingCore.Entities.RentalApplicant", "RentalApplicant")
                        .WithMany("RentalReference")
                        .HasForeignKey("RentalApplicatId")
                        .HasConstraintName("FK_RentalReference_RentalApplicant");
                });
#pragma warning restore 612, 618
        }
    }
}
