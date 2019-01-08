﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REALWorks.AssetServer.Data;

namespace REALWorks.AssetServer.Migrations
{
    [DbContext(typeof(REALAssetContext))]
    [Migration("20190102214605_InitailMigration")]
    partial class InitailMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("REALWorks.AssetServer.Models.Community", b =>
                {
                    b.Property<int>("CommunityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommunityName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("PropertyAddressId");

                    b.HasKey("CommunityId");

                    b.HasIndex("PropertyAddressId");

                    b.ToTable("Community");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.Furnishing", b =>
                {
                    b.Property<int>("FurnishingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FurnishingCategory")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("FurnishingConditions")
                        .HasMaxLength(350);

                    b.Property<string>("FurnishingItemName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("FurnishingQuantity");

                    b.Property<string>("Notes")
                        .HasMaxLength(650);

                    b.Property<int>("PropertyId");

                    b.HasKey("FurnishingId");

                    b.ToTable("Furnishing");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.ManagementContract", b =>
                {
                    b.Property<int>("ManagementContractId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentTemplateUrl")
                        .HasMaxLength(150);

                    b.Property<DateTime>("ContractSignDate");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool?>("IsRenewal")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("ManagementContractDocUrl")
                        .HasMaxLength(150);

                    b.Property<string>("ManagementContractTitile")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ManagementFeeScale")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PlacementFeeScale")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PropertyId");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("ManagementContractId");

                    b.HasIndex("PropertyId");

                    b.ToTable("ManagementContract");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.OwnerProperty", b =>
                {
                    b.Property<int>("PropertyId");

                    b.Property<int>("PropertyOwnerId");

                    b.HasKey("PropertyId", "PropertyOwnerId");

                    b.HasIndex("PropertyOwnerId");

                    b.ToTable("OwnerProperty");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("FurnishingId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsBasementSuite");

                    b.Property<bool>("IsShared");

                    b.Property<int>("PropertyAddressId");

                    b.Property<int>("PropertyBuildYear");

                    b.Property<string>("PropertyDesc")
                        .HasMaxLength(250);

                    b.Property<int>("PropertyFacilityId");

                    b.Property<int>("PropertyFeatureId");

                    b.Property<string>("PropertyLogoImgUrl")
                        .HasMaxLength(100);

                    b.Property<int?>("PropertyManagerId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PropertyTypeId");

                    b.Property<string>("PropertyVideoUrl")
                        .HasMaxLength(100);

                    b.Property<int>("RentalStatusId");

                    b.Property<int?>("StrataCouncilId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("PropertyId");

                    b.HasIndex("PropertyAddressId");

                    b.HasIndex("PropertyFacilityId");

                    b.HasIndex("PropertyFeatureId");

                    b.HasIndex("PropertyTypeId");

                    b.HasIndex("RentalStatusId");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.PropertyAddress", b =>
                {
                    b.Property<int>("PropertyAddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GpslatitudeValue")
                        .HasColumnName("GPSLatitudeValue")
                        .HasMaxLength(50);

                    b.Property<string>("GpslongitudeValue")
                        .HasColumnName("GPSLongitudeValue")
                        .HasMaxLength(50);

                    b.Property<string>("PropertyCity")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PropertyCountry")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PropertyNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PropertyStateProvince")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PropertyStreet")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PropertySuiteNumber")
                        .HasMaxLength(50);

                    b.Property<string>("PropertyZipPostCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("PropertyAddressId");

                    b.ToTable("PropertyAddress");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.PropertyFacility", b =>
                {
                    b.Property<int>("PropertyFacilityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AirConditioner");

                    b.Property<bool?>("BlindsCurtain")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("CommonFacility");

                    b.Property<bool?>("Dishwasher")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<bool?>("FireAlarmSystem")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("Furniture");

                    b.Property<bool?>("Laundry")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Notes")
                        .HasMaxLength(400);

                    b.Property<string>("Others")
                        .HasMaxLength(350);

                    b.Property<bool?>("Refrigerator")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("SecuritySystem");

                    b.Property<bool?>("Stove")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("Tvinternet")
                        .HasColumnName("TVInternet");

                    b.Property<bool>("UtilityIncluded");

                    b.HasKey("PropertyFacilityId");

                    b.ToTable("PropertyFacility");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.PropertyFeature", b =>
                {
                    b.Property<int>("PropertyFeatureId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BasementAvailable");

                    b.Property<bool>("IsShared");

                    b.Property<string>("Notes")
                        .HasMaxLength(400);

                    b.Property<int>("NumberOfBathrooms");

                    b.Property<int>("NumberOfBedrooms");

                    b.Property<int>("NumberOfLayers");

                    b.Property<int>("NumberOfParking");

                    b.Property<int>("TotalLivingArea");

                    b.HasKey("PropertyFeatureId");

                    b.ToTable("PropertyFeature");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.PropertyImg", b =>
                {
                    b.Property<int>("PropertyImgId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("PropertyId");

                    b.Property<string>("PropertyImgCaption")
                        .HasMaxLength(350);

                    b.Property<string>("PropertyImgTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("PropertyImgId");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyImg");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.PropertyOwner", b =>
                {
                    b.Property<int>("PropertyOwnerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ContactTelephone1")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("ContactTelephone2")
                        .HasMaxLength(25);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("OnlineAccessEnbaled");

                    b.Property<int?>("RoleId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserAvartaImgUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('default')")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('tba')")
                        .HasMaxLength(50);

                    b.HasKey("PropertyOwnerId");

                    b.ToTable("PropertyOwner");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.PropertyType", b =>
                {
                    b.Property<int>("PropertyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(350);

                    b.Property<string>("PropertyType1")
                        .IsRequired()
                        .HasColumnName("PropertyType")
                        .HasMaxLength(50);

                    b.HasKey("PropertyTypeId");

                    b.ToTable("PropertyType");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.RentalStatus", b =>
                {
                    b.Property<int>("RentalStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(350);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("RentalStatusId");

                    b.ToTable("RentalStatus");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.Community", b =>
                {
                    b.HasOne("REALWorks.AssetServer.Models.PropertyAddress", "PropertyAddress")
                        .WithMany("Community")
                        .HasForeignKey("PropertyAddressId")
                        .HasConstraintName("FK_Community_PropertyAddress");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.ManagementContract", b =>
                {
                    b.HasOne("REALWorks.AssetServer.Models.Property", "Property")
                        .WithMany("ManagementContract")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("FK_ManagementContract_Property");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.OwnerProperty", b =>
                {
                    b.HasOne("REALWorks.AssetServer.Models.Property", "Property")
                        .WithMany("OwnerProperty")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("FK_OwnerProperty_Property");

                    b.HasOne("REALWorks.AssetServer.Models.PropertyOwner", "PropertyOwner")
                        .WithMany("OwnerProperty")
                        .HasForeignKey("PropertyOwnerId")
                        .HasConstraintName("FK_OwnerProperty_PropertyOwner");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.Property", b =>
                {
                    b.HasOne("REALWorks.AssetServer.Models.PropertyAddress", "PropertyAddress")
                        .WithMany("Property")
                        .HasForeignKey("PropertyAddressId")
                        .HasConstraintName("FK_Property_PropertyAddress");

                    b.HasOne("REALWorks.AssetServer.Models.PropertyFacility", "PropertyFacility")
                        .WithMany("Property")
                        .HasForeignKey("PropertyFacilityId")
                        .HasConstraintName("FK_Property_PropertyFacility");

                    b.HasOne("REALWorks.AssetServer.Models.PropertyFeature", "PropertyFeature")
                        .WithMany("Property")
                        .HasForeignKey("PropertyFeatureId")
                        .HasConstraintName("FK_Property_PropertyFeature");

                    b.HasOne("REALWorks.AssetServer.Models.PropertyType", "PropertyType")
                        .WithMany("Property")
                        .HasForeignKey("PropertyTypeId")
                        .HasConstraintName("FK_Property_PropertyType");

                    b.HasOne("REALWorks.AssetServer.Models.RentalStatus", "RentalStatus")
                        .WithMany("Property")
                        .HasForeignKey("RentalStatusId")
                        .HasConstraintName("FK_Property_RentalStatus");
                });

            modelBuilder.Entity("REALWorks.AssetServer.Models.PropertyImg", b =>
                {
                    b.HasOne("REALWorks.AssetServer.Models.Property", "Property")
                        .WithMany("PropertyImg")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("FK_PropertyImg_Property");
                });
#pragma warning restore 612, 618
        }
    }
}