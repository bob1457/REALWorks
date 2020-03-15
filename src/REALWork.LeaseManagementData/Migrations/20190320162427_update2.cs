using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWork.LeaseManagementData.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaseTermId",
                table: "Lease");

            migrationBuilder.RenameColumn(
                name: "Regfrigerator",
                table: "RentCoverage",
                newName: "Regigerator");

            migrationBuilder.AddColumn<string>(
                name: "Term",
                table: "Lease",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Term",
                table: "Lease");

            migrationBuilder.RenameColumn(
                name: "Regigerator",
                table: "RentCoverage",
                newName: "Regfrigerator");

            migrationBuilder.AddColumn<int>(
                name: "LeaseTermId",
                table: "Lease",
                nullable: false,
                defaultValue: 0);
        }
    }
}
