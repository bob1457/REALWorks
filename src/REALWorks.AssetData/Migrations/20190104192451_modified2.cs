using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWorks.AssetData.Migrations
{
    public partial class modified2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Property",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Property",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "Property",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Property",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Property",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Property",
                newName: "PropertyId");
        }
    }
}
