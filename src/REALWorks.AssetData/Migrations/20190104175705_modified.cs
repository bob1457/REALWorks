using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWorks.AssetData.Migrations
{
    public partial class modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_GpslatitudeValue",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Address_GpslongitudeValue",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Address_PropertyCity",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Address_PropertyCountry",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Address_PropertyNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Address_PropertyStateProvince",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Address_PropertyStreet",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Address_PropertySuiteNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Address_PropertyZipPostCode",
                table: "Property");

            migrationBuilder.CreateTable(
                name: "PropertyAddress",
                columns: table => new
                {
                    PropertySuiteNumber = table.Column<string>(nullable: true),
                    PropertyNumber = table.Column<string>(nullable: true),
                    PropertyStreet = table.Column<string>(nullable: true),
                    PropertyCity = table.Column<string>(nullable: true),
                    PropertyStateProvince = table.Column<string>(nullable: true),
                    PropertyCountry = table.Column<string>(nullable: true),
                    PropertyZipPostCode = table.Column<string>(nullable: true),
                    GpslongitudeValue = table.Column<string>(nullable: true),
                    GpslatitudeValue = table.Column<string>(nullable: true),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAddress", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_PropertyAddress_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyAddress");

            migrationBuilder.AddColumn<string>(
                name: "Address_GpslatitudeValue",
                table: "Property",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_GpslongitudeValue",
                table: "Property",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PropertyCity",
                table: "Property",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PropertyCountry",
                table: "Property",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PropertyNumber",
                table: "Property",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PropertyStateProvince",
                table: "Property",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PropertyStreet",
                table: "Property",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PropertySuiteNumber",
                table: "Property",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PropertyZipPostCode",
                table: "Property",
                nullable: true);
        }
    }
}
