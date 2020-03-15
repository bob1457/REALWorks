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
    [Migration("20190110233028_update2")]
    partial class update2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("PropertyImgCaption");

                    b.Property<string>("PropertyImgTitle");

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

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Notes");

                    b.Property<bool>("OnlineAccess");

                    b.Property<int?>("RoleId");

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
                            b1.Property<int?>("PropertyId");

                            b1.Property<string>("GpslatitudeValue");

                            b1.Property<string>("GpslongitudeValue");

                            b1.Property<string>("PropertyCity");

                            b1.Property<string>("PropertyCountry");

                            b1.Property<string>("PropertyNumber");

                            b1.Property<string>("PropertyStateProvince");

                            b1.Property<string>("PropertyStreet");

                            b1.Property<string>("PropertySuiteNumber");

                            b1.Property<string>("PropertyZipPostCode");

                            b1.ToTable("PropertyAddress");

                            b1.HasOne("REALWorks.AssetCore.Entities.Property")
                                .WithOne("Address")
                                .HasForeignKey("REALWorks.AssetCore.ValueObjects.PropertyAddress", "PropertyId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("REALWorks.AssetCore.ValueObjects.PropertyFacility", "Facility", b1 =>
                        {
                            b1.Property<int?>("PropertyId");

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

                            b1.ToTable("PropertyFacility");

                            b1.HasOne("REALWorks.AssetCore.Entities.Property")
                                .WithOne("Facility")
                                .HasForeignKey("REALWorks.AssetCore.ValueObjects.PropertyFacility", "PropertyId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("REALWorks.AssetCore.ValueObjects.PropertyFeature", "Feature", b1 =>
                        {
                            b1.Property<int?>("PropertyId");

                            b1.Property<bool>("BasementAvailable");

                            b1.Property<bool>("IsShared");

                            b1.Property<string>("Notes");

                            b1.Property<int>("NumberOfBathrooms");

                            b1.Property<int>("NumberOfBedrooms");

                            b1.Property<int>("NumberOfLayers");

                            b1.Property<int>("NumberOfParking");

                            b1.Property<int>("TotalLivingArea");

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
#pragma warning restore 612, 618
        }
    }
}
