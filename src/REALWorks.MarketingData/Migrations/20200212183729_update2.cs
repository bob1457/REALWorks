﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWorks.MarketingData.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeoLocationId",
                table: "RentalProperty",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GeoLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(maxLength: 350, nullable: false),
                    StateProv = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoLocation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeoLocation");

            migrationBuilder.DropColumn(
                name: "GeoLocationId",
                table: "RentalProperty");
        }
    }
}
