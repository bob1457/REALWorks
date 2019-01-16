using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWorks.AssetData.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyImgCaption",
                table: "PropertyImg",
                newName: "PropertyImgUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyImgUrl",
                table: "PropertyImg",
                newName: "PropertyImgCaption");
        }
    }
}
