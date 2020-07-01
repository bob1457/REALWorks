using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWorks.AssetData.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contract",
                table: "ManagementContract",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SolicitingOnly",
                table: "ManagementContract",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentReceivedDate",
                table: "FeePayment",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDueDate",
                table: "FeePayment",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contract",
                table: "ManagementContract");

            migrationBuilder.DropColumn(
                name: "SolicitingOnly",
                table: "ManagementContract");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentReceivedDate",
                table: "FeePayment",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDueDate",
                table: "FeePayment",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
