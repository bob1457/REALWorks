using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWork.LeaseManagementData.Migrations
{
    public partial class update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceAmount",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "InvoiceDocUrl",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "PaymentAmount",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "RecordCreationDate",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "RecordUpdateDate",
                table: "WorkOrder");

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    WorkOrderId = table.Column<int>(nullable: false),
                    InvoiceAmount = table.Column<decimal>(nullable: false),
                    InvoiceDocUrl = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    PaymentAmount = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.WorkOrderId);
                    table.ForeignKey(
                        name: "FK_Invoice_WorkOrder_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.AddColumn<decimal>(
                name: "InvoiceAmount",
                table: "WorkOrder",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                table: "WorkOrder",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InvoiceDocUrl",
                table: "WorkOrder",
                unicode: false,
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "WorkOrder",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentAmount",
                table: "WorkOrder",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "WorkOrder",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "WorkOrder",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordCreationDate",
                table: "WorkOrder",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordUpdateDate",
                table: "WorkOrder",
                nullable: true);
        }
    }
}
