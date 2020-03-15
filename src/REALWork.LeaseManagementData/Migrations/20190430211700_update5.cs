using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWork.LeaseManagementData.Migrations
{
    public partial class update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActualPaymentDate",
                table: "RentPayment",
                newName: "PaymentReceivedDate");

            migrationBuilder.AddColumn<int>(
                name: "PayMethod",
                table: "RentPayment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RentalForMonth",
                table: "RentPayment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RentalForYear",
                table: "RentPayment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayMethod",
                table: "RentPayment");

            migrationBuilder.DropColumn(
                name: "RentalForMonth",
                table: "RentPayment");

            migrationBuilder.DropColumn(
                name: "RentalForYear",
                table: "RentPayment");

            migrationBuilder.RenameColumn(
                name: "PaymentReceivedDate",
                table: "RentPayment",
                newName: "ActualPaymentDate");
        }
    }
}
