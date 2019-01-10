using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWorks.AssetData.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyManagerId",
                table: "Property");

            migrationBuilder.AddColumn<string>(
                name: "PropertyManagerUserName",
                table: "Property",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyManagerUserName",
                table: "Property");

            migrationBuilder.AddColumn<int>(
                name: "PropertyManagerId",
                table: "Property",
                nullable: true,
                defaultValueSql: "((0))");
        }
    }
}
