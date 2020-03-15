using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWorks.AssetData.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FurnishingId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "PropertyFacilityId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "PropertyFeatureId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "PropertyTypeId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "RentalStatusId",
                table: "Property");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Property",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Property",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PropertyFacility",
                columns: table => new
                {
                    Stove = table.Column<bool>(nullable: true),
                    Refrigerator = table.Column<bool>(nullable: true),
                    Dishwasher = table.Column<bool>(nullable: true),
                    AirConditioner = table.Column<bool>(nullable: false),
                    Laundry = table.Column<bool>(nullable: true),
                    BlindsCurtain = table.Column<bool>(nullable: true),
                    Furniture = table.Column<bool>(nullable: false),
                    Tvinternet = table.Column<bool>(nullable: false),
                    CommonFacility = table.Column<bool>(nullable: false),
                    SecuritySystem = table.Column<bool>(nullable: false),
                    UtilityIncluded = table.Column<bool>(nullable: false),
                    FireAlarmSystem = table.Column<bool>(nullable: true),
                    Others = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyFacility", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_PropertyFacility_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyFeature",
                columns: table => new
                {
                    NumberOfBedrooms = table.Column<int>(nullable: false),
                    NumberOfBathrooms = table.Column<int>(nullable: false),
                    NumberOfLayers = table.Column<int>(nullable: false),
                    NumberOfParking = table.Column<int>(nullable: false),
                    BasementAvailable = table.Column<bool>(nullable: false),
                    TotalLivingArea = table.Column<int>(nullable: false),
                    IsShared = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyFeature", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_PropertyFeature_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImg",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    PropertyImgTitle = table.Column<string>(nullable: true),
                    PropertyImgCaption = table.Column<string>(nullable: true),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImg_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyOwner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "('tba')"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 100, nullable: false),
                    ContactTelephone1 = table.Column<string>(maxLength: 25, nullable: false),
                    ContactTelephone2 = table.Column<string>(maxLength: 25, nullable: true),
                    OnlineAccess = table.Column<bool>(nullable: false),
                    UserAvartaImgUrl = table.Column<string>(maxLength: 100, nullable: false, defaultValueSql: "('default')"),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    RoleId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnerProperty",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false),
                    PropertyOwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerProperty", x => new { x.PropertyId, x.PropertyOwnerId });
                    table.ForeignKey(
                        name: "FK_OwnerProperty_Property",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OwnerProperty_PropertyOwner",
                        column: x => x.PropertyOwnerId,
                        principalTable: "PropertyOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnerProperty_PropertyOwnerId",
                table: "OwnerProperty",
                column: "PropertyOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImg_PropertyId",
                table: "PropertyImg",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnerProperty");

            migrationBuilder.DropTable(
                name: "PropertyFacility");

            migrationBuilder.DropTable(
                name: "PropertyFeature");

            migrationBuilder.DropTable(
                name: "PropertyImg");

            migrationBuilder.DropTable(
                name: "PropertyOwner");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Property");

            migrationBuilder.AddColumn<int>(
                name: "FurnishingId",
                table: "Property",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "PropertyFacilityId",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyFeatureId",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyTypeId",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RentalStatusId",
                table: "Property",
                nullable: false,
                defaultValue: 0);
        }
    }
}
