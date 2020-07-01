﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REALWorks.AssetData;

namespace REALWorks.AssetData.Migrations
{
    [DbContext(typeof(AppDataBaseContext))]
    [Migration("20200629155223_update4")]
    partial class update4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("REALWorks.AssetCore.Entities.FeePayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ActualPaymentAmt")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("Balance")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime>("Created");

                    b.Property<string>("FeeForMonth");

                    b.Property<string>("FeeForYear");

                    b.Property<int>("InChargeOwnerId");

                    b.Property<bool>("IsOnTime");

                    b.Property<int>("ManagementContractId");

                    b.Property<string>("MangementFeeType")
                        .IsRequired();

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Note")
                        .HasMaxLength(450);

                    b.Property<string>("PayMethod")
                        .IsRequired();

                    b.Property<DateTime>("PaymentDueDate");

                    b.Property<DateTime>("PaymentReceivedDate");

                    b.Property<decimal>("ScheduledPaymentAmt")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id");

                    b.HasIndex("ManagementContractId");

                    b.ToTable("FeePayment");
                });

            modelBuilder.Entity("REALWorks.AssetCore.Entities.ManagementContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contract");

                    b.Property<DateTime>("ContractSignDate");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ManagementContractDocUrl")
                        .HasMaxLength(150);

                    b.Property<string>("ManagementContractTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ManagementFeeScale")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Notes");

                    b.Property<string>("PlacementFeeScale")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PropertyId");

                    b.Property<bool>("SolicitingOnly");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("ManagementContract");
                });

            modelBuilder.Entity("REALWorks.AssetCore.Entities.OwnerProperty", b =>
                {
                    b.Property<int>("PropertyId");

                    b.Property<int>("PropertyOwnerId");

                    b.HasKey("PropertyId", "PropertyOwnerId");

                    b.HasIndex("PropertyOwnerId");

                    b.ToTable("OwnerProperty");
                });

            modelBuilder.Entity("REALWorks.AssetCore.Entities.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsBasementSuite");

                    b.Property<bool>("IsShared");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("PropertyBuildYear");

                    b.Property<string>("PropertyDesc")
                        .HasMaxLength(250);

                    b.Property<string>("PropertyLogoImgUrl")
                        .HasMaxLength(100);

                    b.Property<string>("PropertyManagerUserName");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PropertyVideoUrl")
                        .HasMaxLength(100);

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<int?>("StrataCouncilId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("REALWorks.AssetCore.Entities.PropertyImg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("PropertyId");

                    b.Property<string>("PropertyImgTitle");

                    b.Property<string>("PropertyImgUrl");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyImg");
                });

            modelBuilder.Entity("REALWorks.AssetCore.Entities.PropertyOwner", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Notes");

                    b.Property<bool>("OnlineAccess");

                    b.Property<int>("RoleId");

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

                    b.HasKey("Id");

                    b.ToTable("PropertyOwner");
                });

            modelBuilder.Entity("REALWorks.AssetCore.Entities.FeePayment", b =>
                {
                    b.HasOne("REALWorks.AssetCore.Entities.ManagementContract", "Contract")
                        .WithMany("FeePayment")
                        .HasForeignKey("ManagementContractId")
                        .HasConstraintName("FK_FeePayment_ManagementContract");
                });

            modelBuilder.Entity("REALWorks.AssetCore.Entities.ManagementContract", b =>
                {
                    b.HasOne("REALWorks.AssetCore.Entities.Property", "Property")
                        .WithMany("ManagementContract")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("FK_ManagementContract_Property");
                });

            modelBuilder.Entity("REALWorks.AssetCore.Entities.OwnerProperty", b =>
                {
                    b.HasOne("REALWorks.AssetCore.Entities.Property", "Property")
                        .WithMany("OwnerProperty")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("FK_OwnerProperty_Property");

                    b.HasOne("REALWorks.AssetCore.Entities.PropertyOwner", "PropertyOwner")
                        .WithMany("OwnerProperty")
                        .HasForeignKey("PropertyOwnerId")
                        .HasConstraintName("FK_OwnerProperty_PropertyOwner");
                });

            modelBuilder.Entity("REALWorks.AssetCore.Entities.Property", b =>
                {
                    b.OwnsOne("REALWorks.AssetCore.ValueObjects.PropertyAddress", "Address", b1 =>
                        {
                            b1.Property<int>("PropertyId");

                            b1.Property<string>("GpslatitudeValue");

                            b1.Property<string>("GpslongitudeValue");

                            b1.Property<string>("PropertyCity");

                            b1.Property<string>("PropertyCountry");

                            b1.Property<string>("PropertyNumber");

                            b1.Property<string>("PropertyStateProvince");

                            b1.Property<string>("PropertyStreet");

                            b1.Property<string>("PropertySuiteNumber");

                            b1.Property<string>("PropertyZipPostCode");

                            b1.HasKey("PropertyId");

                            b1.ToTable("PropertyAddress");

                            b1.HasOne("REALWorks.AssetCore.Entities.Property")
                                .WithOne("Address")
                                .HasForeignKey("REALWorks.AssetCore.ValueObjects.PropertyAddress", "PropertyId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("REALWorks.AssetCore.ValueObjects.PropertyFacility", "Facility", b1 =>
                        {
                            b1.Property<int>("PropertyId");

                            b1.Property<bool>("AirConditioner");

                            b1.Property<bool?>("BlindsCurtain");

                            b1.Property<bool>("CommonFacility");

                            b1.Property<bool?>("Dishwasher");

                            b1.Property<bool?>("FireAlarmSystem");

                            b1.Property<bool>("Furniture");

                            b1.Property<bool?>("Laundry");

                            b1.Property<string>("Notes");

                            b1.Property<string>("Others");

                            b1.Property<bool?>("Refrigerator");

                            b1.Property<bool>("SecuritySystem");

                            b1.Property<bool?>("Stove");

                            b1.Property<bool>("Tvinternet");

                            b1.Property<bool>("UtilityIncluded");

                            b1.HasKey("PropertyId");

                            b1.ToTable("PropertyFacility");

                            b1.HasOne("REALWorks.AssetCore.Entities.Property")
                                .WithOne("Facility")
                                .HasForeignKey("REALWorks.AssetCore.ValueObjects.PropertyFacility", "PropertyId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("REALWorks.AssetCore.ValueObjects.PropertyFeature", "Feature", b1 =>
                        {
                            b1.Property<int>("PropertyId");

                            b1.Property<bool>("BasementAvailable");

                            b1.Property<bool>("IsShared");

                            b1.Property<string>("Notes");

                            b1.Property<int>("NumberOfBathrooms");

                            b1.Property<int>("NumberOfBedrooms");

                            b1.Property<int>("NumberOfLayers");

                            b1.Property<int>("NumberOfParking");

                            b1.Property<int>("TotalLivingArea");

                            b1.HasKey("PropertyId");

                            b1.ToTable("PropertyFeature");

                            b1.HasOne("REALWorks.AssetCore.Entities.Property")
                                .WithOne("Feature")
                                .HasForeignKey("REALWorks.AssetCore.ValueObjects.PropertyFeature", "PropertyId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("REALWorks.AssetCore.Entities.PropertyImg", b =>
                {
                    b.HasOne("REALWorks.AssetCore.Entities.Property", "Property")
                        .WithMany("PropertyImg")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("REALWorks.AssetCore.Entities.PropertyOwner", b =>
                {
                    b.OwnsOne("REALWorks.AssetCore.ValueObjects.OwnerAddress", "Address", b1 =>
                        {
                            b1.Property<int>("PropertyOwnerId");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("StateProvince");

                            b1.Property<string>("StreetNumber");

                            b1.Property<string>("ZipPostCode");

                            b1.HasKey("PropertyOwnerId");

                            b1.ToTable("OwnerAddress");

                            b1.HasOne("REALWorks.AssetCore.Entities.PropertyOwner")
                                .WithOne("Address")
                                .HasForeignKey("REALWorks.AssetCore.ValueObjects.OwnerAddress", "PropertyOwnerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
