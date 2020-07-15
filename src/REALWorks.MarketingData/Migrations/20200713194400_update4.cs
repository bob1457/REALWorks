using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWorks.MarketingData.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCheckScore",
                table: "RentalApplicantScoreCard",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IncomeCheckScore",
                table: "RentalApplicantScoreCard",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OtherCheckScore",
                table: "RentalApplicantScoreCard",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceCheckScore",
                table: "RentalApplicantScoreCard",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCheckScore",
                table: "RentalApplicantScoreCard");

            migrationBuilder.DropColumn(
                name: "IncomeCheckScore",
                table: "RentalApplicantScoreCard");

            migrationBuilder.DropColumn(
                name: "OtherCheckScore",
                table: "RentalApplicantScoreCard");

            migrationBuilder.DropColumn(
                name: "ReferenceCheckScore",
                table: "RentalApplicantScoreCard");
        }
    }
}
