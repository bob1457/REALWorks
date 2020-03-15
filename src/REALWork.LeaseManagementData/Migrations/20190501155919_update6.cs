using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWork.LeaseManagementData.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "RentPayment");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "RentPayment");

            migrationBuilder.AlterColumn<string>(
                name: "PayMethod",
                table: "RentPayment",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PayMethod",
                table: "RentPayment",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "RentPayment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "RentPayment",
                nullable: true);
        }
    }
}
