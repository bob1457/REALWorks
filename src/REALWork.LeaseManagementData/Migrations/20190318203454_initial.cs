using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWork.LeaseManagementData.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewTenant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 150, nullable: false),
                    ContactTelephone1 = table.Column<string>(maxLength: 50, nullable: false),
                    ContactTelephone2 = table.Column<string>(maxLength: 50, nullable: true),
                    ContactOthers = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewTenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalProperty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ListinglId = table.Column<int>(nullable: false),
                    PropertyName = table.Column<string>(maxLength: 50, nullable: false),
                    PropertyType = table.Column<string>(maxLength: 50, nullable: false),
                    PropertyBuildYear = table.Column<int>(nullable: false),
                    IsShared = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    IsBasementSuite = table.Column<bool>(nullable: false),
                    NumberOfBedrooms = table.Column<int>(nullable: false),
                    NumberOfBathrooms = table.Column<int>(nullable: false),
                    NumberOfLayers = table.Column<int>(nullable: false),
                    NumberOfParking = table.Column<int>(nullable: false),
                    TotalLivingArea = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 450, nullable: true),
                    PmUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    VendorBusinessName = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    VendorDesc = table.Column<string>(unicode: false, maxLength: 450, nullable: true),
                    VendorSpecialty = table.Column<string>(maxLength: 150, nullable: false),
                    VendorContactTelephone1 = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    VendorContactOthers = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    VendorContactEmail = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    OnlineAccessEnbaled = table.Column<bool>(nullable: false),
                    UserAvartaImgUrl = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    StreetNum = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StateProvince = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ZipPostCode = table.Column<string>(nullable: true),
                    RentalPropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.RentalPropertyId);
                    table.ForeignKey(
                        name: "FK_Address_RentalProperty_RentalPropertyId",
                        column: x => x.RentalPropertyId,
                        principalTable: "RentalProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lease",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    LeaseTitle = table.Column<string>(maxLength: 150, nullable: false),
                    LeaseDesc = table.Column<string>(maxLength: 4000, nullable: true),
                    RentalPropertyId = table.Column<int>(nullable: false),
                    LeaseStartDate = table.Column<DateTime>(nullable: false),
                    LeaseEndDate = table.Column<DateTime>(nullable: false),
                    LeaseTermId = table.Column<int>(nullable: false),
                    RentFrequency = table.Column<string>(maxLength: 50, nullable: false),
                    RentAmount = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    RentDueOn = table.Column<string>(maxLength: 150, nullable: false),
                    DamageDepositAmount = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    PetDepositAmount = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    LeaseSignDate = table.Column<DateTime>(nullable: false),
                    LeaseAgreementDocUrl = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsAddendumAvailable = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lease_RentalProperty",
                        column: x => x.RentalPropertyId,
                        principalTable: "RentalProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyVisit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    RentalPropertyId = table.Column<int>(nullable: false),
                    VisitPurpose = table.Column<string>(maxLength: 150, nullable: false),
                    MileageDriven = table.Column<string>(maxLength: 100, nullable: true),
                    TimeSpent = table.Column<string>(maxLength: 50, nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    VisitStartTime = table.Column<string>(maxLength: 50, nullable: false),
                    VisitEndTime = table.Column<string>(maxLength: 50, nullable: false),
                    HoursSpent = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyVisit_RentalProperty",
                        column: x => x.RentalPropertyId,
                        principalTable: "RentalProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    WorkOrderName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    WorkOrderDetails = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    WorkOrderCategory = table.Column<string>(maxLength: 50, nullable: false),
                    RentalPropertyId = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    WorkOrderType = table.Column<string>(maxLength: 50, nullable: false),
                    InvoiceAmount = table.Column<decimal>(nullable: false),
                    InvoiceDocUrl = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsOwnerAuthorized = table.Column<bool>(nullable: false),
                    IsEmergency = table.Column<bool>(nullable: false),
                    WorkOrderStatus = table.Column<string>(maxLength: 50, nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PaymentMethod = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PaymentAmount = table.Column<decimal>(nullable: true),
                    RecordCreationDate = table.Column<DateTime>(nullable: false),
                    RecordUpdateDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(maxLength: 550, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrder_RentalProperty",
                        column: x => x.RentalPropertyId,
                        principalTable: "RentalProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrder_Vendor",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    LeaseId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    ContactEmial = table.Column<string>(maxLength: 150, nullable: false),
                    ContztTel = table.Column<string>(maxLength: 150, nullable: false),
                    ContactOthers = table.Column<string>(maxLength: 250, nullable: true),
                    isPropertyManager = table.Column<bool>(nullable: false),
                    AddressStreetNumber = table.Column<string>(maxLength: 50, nullable: false),
                    AddressCity = table.Column<string>(maxLength: 50, nullable: false),
                    AddressStateProv = table.Column<string>(maxLength: 50, nullable: false),
                    AddressZipPostCode = table.Column<string>(maxLength: 50, nullable: false),
                    AddressCountry = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agent_Lease",
                        column: x => x.LeaseId,
                        principalTable: "Lease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentCoverage",
                columns: table => new
                {
                    LeaseId = table.Column<int>(nullable: false),
                    Water = table.Column<bool>(nullable: false),
                    Cablevison = table.Column<bool>(nullable: false),
                    Electricity = table.Column<bool>(nullable: false),
                    Internet = table.Column<bool>(nullable: false),
                    Heat = table.Column<bool>(nullable: false),
                    NaturalGas = table.Column<bool>(nullable: false),
                    SewageDisposal = table.Column<bool>(nullable: false),
                    SnowRemoval = table.Column<bool>(nullable: false),
                    Storage = table.Column<bool>(nullable: false),
                    RecreationFacility = table.Column<bool>(nullable: false),
                    GarbageCollection = table.Column<bool>(nullable: false),
                    RecycleServices = table.Column<bool>(nullable: false),
                    KitchenScrapCollection = table.Column<bool>(nullable: false),
                    Laundry = table.Column<bool>(nullable: false),
                    FreeLaundry = table.Column<bool>(nullable: false),
                    Regfrigerator = table.Column<bool>(nullable: false),
                    Dishwasher = table.Column<bool>(nullable: false),
                    StoveOven = table.Column<bool>(nullable: false),
                    WindowCovering = table.Column<bool>(nullable: false),
                    Furniture = table.Column<bool>(nullable: false),
                    Carpets = table.Column<bool>(nullable: false),
                    ParkingStall = table.Column<int>(nullable: false),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentCoverage", x => x.LeaseId);
                    table.ForeignKey(
                        name: "FK_RentCoverage_Lease_LeaseId",
                        column: x => x.LeaseId,
                        principalTable: "Lease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    LeaseId = table.Column<int>(nullable: false),
                    ScheduledPaymentAmt = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    ActualPaymentAmt = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(nullable: true),
                    ActualPaymentDate = table.Column<DateTime>(nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    IsOnTime = table.Column<bool>(nullable: false),
                    InChargeTenantId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 450, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentPayment_Lease",
                        column: x => x.LeaseId,
                        principalTable: "Lease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "('tba')"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 150, nullable: false),
                    ContactTelephone1 = table.Column<string>(maxLength: 50, nullable: false),
                    ContactTelephone2 = table.Column<string>(maxLength: 50, nullable: true),
                    ContactOthers = table.Column<string>(maxLength: 250, nullable: false),
                    OnlineAccessEnbaled = table.Column<bool>(nullable: false),
                    UserAvartaImgUrl = table.Column<string>(maxLength: 200, nullable: false, defaultValueSql: "('default')"),
                    LeaseId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenant_Lease",
                        column: x => x.LeaseId,
                        principalTable: "Lease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agent_LeaseId",
                table: "Agent",
                column: "LeaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lease_RentalPropertyId",
                table: "Lease",
                column: "RentalPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyVisit_RentalPropertyId",
                table: "PropertyVisit",
                column: "RentalPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_RentPayment_LeaseId",
                table: "RentPayment",
                column: "LeaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_LeaseId",
                table: "Tenant",
                column: "LeaseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_RentalPropertyId",
                table: "WorkOrder",
                column: "RentalPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_VendorId",
                table: "WorkOrder",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "NewTenant");

            migrationBuilder.DropTable(
                name: "PropertyVisit");

            migrationBuilder.DropTable(
                name: "RentCoverage");

            migrationBuilder.DropTable(
                name: "RentPayment");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "WorkOrder");

            migrationBuilder.DropTable(
                name: "Lease");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "RentalProperty");
        }
    }
}
