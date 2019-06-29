using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWorks.AssetData.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeePayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ManagementContractId = table.Column<int>(nullable: false),
                    ScheduledPaymentAmt = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    ActualPaymentAmt = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    PayMethod = table.Column<string>(nullable: false),
                    MangementFeeType = table.Column<string>(nullable: false),
                    PaymentDueDate = table.Column<DateTime>(nullable: true),
                    PaymentReceivedDate = table.Column<DateTime>(nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    IsOnTime = table.Column<bool>(nullable: false),
                    InChargeOwnerId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 450, nullable: true),
                    FeeForMonth = table.Column<string>(nullable: true),
                    FeeForYear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeePayment_ManagementContract",
                        column: x => x.ManagementContractId,
                        principalTable: "ManagementContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeePayment_ManagementContractId",
                table: "FeePayment",
                column: "ManagementContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeePayment");
        }
    }
}
