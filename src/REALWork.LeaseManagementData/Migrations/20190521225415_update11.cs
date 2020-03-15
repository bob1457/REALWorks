using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWork.LeaseManagementData.Migrations
{
    public partial class update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    RequestSubject = table.Column<string>(nullable: true),
                    ServiceCategory = table.Column<string>(nullable: true),
                    RequestDetails = table.Column<string>(maxLength: 1000, nullable: true),
                    Urgent = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    LeaseId = table.Column<int>(nullable: false),
                    RequestorId = table.Column<int>(nullable: false),
                    WorkOrderId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServieRequest_Lease",
                        column: x => x.LeaseId,
                        principalTable: "Lease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ServiceRequestId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ResponderId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequestComment_ServiceRequest",
                        column: x => x.ServiceRequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ServiceRequestId",
                table: "Comment",
                column: "ServiceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_LeaseId",
                table: "Request",
                column: "LeaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Request");
        }
    }
}
