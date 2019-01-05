using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWorks.AssetData.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PropertyName = table.Column<string>(maxLength: 50, nullable: false),
                    PropertyDesc = table.Column<string>(maxLength: 250, nullable: true),
                    PropertyTypeId = table.Column<int>(nullable: false),
                    StrataCouncilId = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    PropertyFeatureId = table.Column<int>(nullable: false),
                    PropertyFacilityId = table.Column<int>(nullable: false),
                    PropertyManagerId = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    PropertyLogoImgUrl = table.Column<string>(maxLength: 100, nullable: true),
                    PropertyVideoUrl = table.Column<string>(maxLength: 100, nullable: true),
                    PropertyBuildYear = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsShared = table.Column<bool>(nullable: false),
                    FurnishingId = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    RentalStatusId = table.Column<int>(nullable: false),
                    IsBasementSuite = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Address_PropertySuiteNumber = table.Column<string>(nullable: true),
                    Address_PropertyNumber = table.Column<string>(nullable: true),
                    Address_PropertyStreet = table.Column<string>(nullable: true),
                    Address_PropertyCity = table.Column<string>(nullable: true),
                    Address_PropertyStateProvince = table.Column<string>(nullable: true),
                    Address_PropertyCountry = table.Column<string>(nullable: true),
                    Address_PropertyZipPostCode = table.Column<string>(nullable: true),
                    Address_GpslongitudeValue = table.Column<string>(nullable: true),
                    Address_GpslatitudeValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Property");
        }
    }
}
