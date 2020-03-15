using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace REALWorks.AuthServer.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telepone2",
                table: "AspNetUsers",
                newName: "Telephone2");

            migrationBuilder.RenameColumn(
                name: "Telepone1",
                table: "AspNetUsers",
                newName: "Telephone1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telephone2",
                table: "AspNetUsers",
                newName: "Telepone2");

            migrationBuilder.RenameColumn(
                name: "Telephone1",
                table: "AspNetUsers",
                newName: "Telepone1");
        }
    }
}
