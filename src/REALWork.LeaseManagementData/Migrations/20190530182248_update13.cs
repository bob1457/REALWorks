using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REALWork.LeaseManagementData.Migrations
{
    public partial class update13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    MoveInDate = table.Column<DateTime>(nullable: false),
                    MoveOutDate = table.Column<DateTime>(nullable: false),
                    MoveInInspectionDate = table.Column<DateTime>(nullable: false),
                    MoveOutIspectionDate = table.Column<DateTime>(nullable: false),
                    MoveInInspectionReportDocUrl = table.Column<string>(nullable: true),
                    MoveOutInspectionReportDocUrl = table.Column<string>(nullable: true),
                    LeaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriopertyInspection_Lease",
                        column: x => x.LeaseId,
                        principalTable: "Lease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasementCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    LightingB = table.Column<int>(nullable: false),
                    LightingE = table.Column<int>(nullable: false),
                    LightingCommentB = table.Column<string>(nullable: true),
                    LightingCommentE = table.Column<string>(nullable: true),
                    WindowsCoveringB = table.Column<int>(nullable: false),
                    WindowsCoveringE = table.Column<int>(nullable: false),
                    WindowsCoveringCommentB = table.Column<int>(nullable: false),
                    WindowsCoveringCommentE = table.Column<int>(nullable: false),
                    ElectricalOutletsB = table.Column<int>(nullable: false),
                    ElectricalOutletsE = table.Column<int>(nullable: false),
                    ElectricalOutletsCommentB = table.Column<string>(nullable: true),
                    ElectricalOutletsCommentE = table.Column<string>(nullable: true),
                    StairwellB = table.Column<int>(nullable: false),
                    StairwellE = table.Column<int>(nullable: false),
                    StairwellCommentB = table.Column<string>(nullable: true),
                    StairwellCommentE = table.Column<string>(nullable: true),
                    WallsAndFloorCarpetB = table.Column<int>(nullable: false),
                    WallsAndFloorCarpetE = table.Column<int>(nullable: false),
                    WallsAndFloorCarpetCommentB = table.Column<string>(nullable: true),
                    WallsAndFloorCarpetCommentE = table.Column<string>(nullable: true),
                    FurnacePlumbingB = table.Column<int>(nullable: false),
                    FurnacePlumbingE = table.Column<int>(nullable: false),
                    FurnacePlumbingCommentB = table.Column<string>(nullable: true),
                    FurnacePlumbingCommentE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasementCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_BasementCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DinningRoomCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    WallAndTrimeB = table.Column<int>(nullable: false),
                    WallAndTrimeE = table.Column<int>(nullable: false),
                    WallAndTrimsCommentB = table.Column<string>(nullable: true),
                    WallAndTrimsCommentE = table.Column<string>(nullable: true),
                    CeilingsB = table.Column<int>(nullable: false),
                    CeilingsE = table.Column<int>(nullable: false),
                    CeilingsCommentB = table.Column<string>(nullable: true),
                    CeilingsCommentE = table.Column<string>(nullable: true),
                    LightingB = table.Column<int>(nullable: false),
                    LightingE = table.Column<int>(nullable: false),
                    LightingCommentB = table.Column<string>(nullable: true),
                    LightingCommentE = table.Column<string>(nullable: true),
                    WindowsCoveringB = table.Column<int>(nullable: false),
                    WindowsCoveringE = table.Column<int>(nullable: false),
                    WindowsCoveringCommentB = table.Column<int>(nullable: false),
                    WindowsCoveringCommentE = table.Column<int>(nullable: false),
                    ElectricalOutletsB = table.Column<int>(nullable: false),
                    ElectricalOutletsE = table.Column<int>(nullable: false),
                    ElectricalOutletsCommentB = table.Column<string>(nullable: true),
                    ElectricalOutletsCommentE = table.Column<string>(nullable: true),
                    FloorCarpetB = table.Column<int>(nullable: false),
                    FloorCarpetE = table.Column<int>(nullable: false),
                    FloorCarpetCommentB = table.Column<string>(nullable: true),
                    FloorCarpetCommentE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinningRoomCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_DinningRoomCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    WallAndTrimeB = table.Column<int>(nullable: false),
                    WallAndTrimeE = table.Column<int>(nullable: false),
                    WallAndTrimsCommentB = table.Column<string>(nullable: true),
                    WallAndTrimsCommentE = table.Column<string>(nullable: true),
                    CeilingsB = table.Column<int>(nullable: false),
                    CeilingsE = table.Column<int>(nullable: false),
                    CeilingsCommentB = table.Column<string>(nullable: true),
                    CeilingsCommentE = table.Column<string>(nullable: true),
                    ClosetsB = table.Column<int>(nullable: false),
                    ClosetsE = table.Column<int>(nullable: false),
                    ClosetsCommentB = table.Column<string>(nullable: true),
                    ClosetsCommentE = table.Column<string>(nullable: true),
                    LightingB = table.Column<int>(nullable: false),
                    LightingE = table.Column<int>(nullable: false),
                    LightingCommentB = table.Column<string>(nullable: true),
                    LightingCommentE = table.Column<string>(nullable: true),
                    WindowsCoveringB = table.Column<int>(nullable: false),
                    WindowsCoveringE = table.Column<int>(nullable: false),
                    WindowsCoveringCommentB = table.Column<int>(nullable: false),
                    WindowsCoveringCommentE = table.Column<int>(nullable: false),
                    ElectricalOutletsB = table.Column<int>(nullable: false),
                    ElectricalOutletsE = table.Column<int>(nullable: false),
                    ElectricalOutletsCommentB = table.Column<string>(nullable: true),
                    ElectricalOutletsCommentE = table.Column<string>(nullable: true),
                    FloorCarpetB = table.Column<int>(nullable: false),
                    FloorCarpetE = table.Column<int>(nullable: false),
                    FloorCarpetCommentB = table.Column<string>(nullable: true),
                    FloorCarpetCommentE = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_EntryCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExteriorCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    LightingB = table.Column<int>(nullable: false),
                    LightingE = table.Column<int>(nullable: false),
                    LightingCommentB = table.Column<string>(nullable: true),
                    LightingCommentE = table.Column<string>(nullable: true),
                    WindowsCoveringB = table.Column<int>(nullable: false),
                    WindowsCoveringE = table.Column<int>(nullable: false),
                    WindowsCoveringCommentB = table.Column<int>(nullable: false),
                    WindowsCoveringCommentE = table.Column<int>(nullable: false),
                    EntrancesB = table.Column<int>(nullable: false),
                    EntrancesE = table.Column<int>(nullable: false),
                    EntrancesCommentB = table.Column<string>(nullable: true),
                    EntrancesCommentE = table.Column<string>(nullable: true),
                    PatioBalconyDoorsB = table.Column<int>(nullable: false),
                    PatioBalconyDoorsE = table.Column<int>(nullable: false),
                    PatioBalconyDoorsCommentB = table.Column<int>(nullable: false),
                    PatioBalconyDoorsCommentE = table.Column<int>(nullable: false),
                    GarbageContainersB = table.Column<int>(nullable: false),
                    GarbageContainersE = table.Column<int>(nullable: false),
                    GarbageContainersCommentB = table.Column<int>(nullable: false),
                    GarbageContainersCommentE = table.Column<int>(nullable: false),
                    GlassAndFramesB = table.Column<int>(nullable: false),
                    GlassAndFramesE = table.Column<int>(nullable: false),
                    GlassAndFramesCommentB = table.Column<int>(nullable: false),
                    GlassAndFramesCommentE = table.Column<int>(nullable: false),
                    StuccoSidingB = table.Column<int>(nullable: false),
                    StuccoSidingE = table.Column<int>(nullable: false),
                    StuccoSidingCommentB = table.Column<int>(nullable: false),
                    StuccoSidingCommentE = table.Column<int>(nullable: false),
                    GroundsAndWalksB = table.Column<int>(nullable: false),
                    GroundsAndWalksE = table.Column<int>(nullable: false),
                    GroundsAndWalksCommentB = table.Column<int>(nullable: false),
                    GroundsAndWalksCommentE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteriorCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_ExteriorCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GarageParkingAreaCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    ElectricalOutletsB = table.Column<int>(nullable: false),
                    ElectricalOutletsE = table.Column<int>(nullable: false),
                    ElectricalOutletsCommentB = table.Column<string>(nullable: true),
                    ElectricalOutletsCommentE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageParkingAreaCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_GarageParkingAreaCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeyAndControlCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    EntranceKeysIssued = table.Column<string>(nullable: true),
                    EntranceKeysReturned = table.Column<string>(nullable: true),
                    UnitKeysIssed = table.Column<bool>(nullable: false),
                    UnitKeysReturned = table.Column<bool>(nullable: false),
                    EUnitDeadlocksIssed = table.Column<bool>(nullable: false),
                    EUnitDeadlocksReturned = table.Column<bool>(nullable: false),
                    ParkingRemoteControlIssed = table.Column<bool>(nullable: false),
                    ParkingRemoteControlReturned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyAndControlCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_KeyAndControlCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitchenCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    WallAndTrimeB = table.Column<int>(nullable: false),
                    WallAndTrimeE = table.Column<int>(nullable: false),
                    WallAndTrimsCommentB = table.Column<string>(nullable: true),
                    WallAndTrimsCommentE = table.Column<string>(nullable: true),
                    CeilingsB = table.Column<int>(nullable: false),
                    CeilingsE = table.Column<int>(nullable: false),
                    CeilingsCommentB = table.Column<string>(nullable: true),
                    CeilingsCommentE = table.Column<string>(nullable: true),
                    ClosetsB = table.Column<int>(nullable: false),
                    ClosetsE = table.Column<int>(nullable: false),
                    ClosetsCommentB = table.Column<string>(nullable: true),
                    ClosetsCommentE = table.Column<string>(nullable: true),
                    LightingB = table.Column<int>(nullable: false),
                    LightingE = table.Column<int>(nullable: false),
                    LightingCommentB = table.Column<string>(nullable: true),
                    LightingCommentE = table.Column<string>(nullable: true),
                    WindowsCoveringB = table.Column<int>(nullable: false),
                    WindowsCoveringE = table.Column<int>(nullable: false),
                    WindowsCoveringCommentB = table.Column<int>(nullable: false),
                    WindowsCoveringCommentE = table.Column<int>(nullable: false),
                    ElectricalOutletsB = table.Column<int>(nullable: false),
                    ElectricalOutletsE = table.Column<int>(nullable: false),
                    ElectricalOutletsCommentB = table.Column<string>(nullable: true),
                    ElectricalOutletsCommentE = table.Column<string>(nullable: true),
                    FloorCarpetB = table.Column<int>(nullable: false),
                    FloorCarpetE = table.Column<int>(nullable: false),
                    FloorCarpetCommentB = table.Column<string>(nullable: true),
                    FloorCarpetCommentE = table.Column<string>(nullable: true),
                    OvenB = table.Column<int>(nullable: false),
                    OvenE = table.Column<int>(nullable: false),
                    OvenCommentB = table.Column<int>(nullable: false),
                    OvenCommentE = table.Column<int>(nullable: false),
                    CountertopB = table.Column<int>(nullable: false),
                    CountertopE = table.Column<int>(nullable: false),
                    CountertopCommentB = table.Column<string>(nullable: true),
                    CountertopCommentE = table.Column<string>(nullable: true),
                    CabinetsAndDoorsB = table.Column<int>(nullable: false),
                    CabinetsAndDoorsE = table.Column<int>(nullable: false),
                    CabinetsAndDoorsCommentB = table.Column<string>(nullable: true),
                    CabinetsAndDoorsCommentE = table.Column<string>(nullable: true),
                    HoodAndFanB = table.Column<int>(nullable: false),
                    HoodAndFanE = table.Column<int>(nullable: false),
                    HoodAndCommentFanB = table.Column<string>(nullable: true),
                    HoodAndCommentFanE = table.Column<string>(nullable: true),
                    TapsSinksB = table.Column<int>(nullable: false),
                    TapsSinksE = table.Column<int>(nullable: false),
                    TapsSinksCommentB = table.Column<string>(nullable: true),
                    TapsSinksCommentE = table.Column<string>(nullable: true),
                    RefrigeratorExteriorB = table.Column<int>(nullable: false),
                    RefrigeratorExteriorE = table.Column<int>(nullable: false),
                    RefrigeratorExteriorCommentB = table.Column<string>(nullable: true),
                    RefrigeratorExteriorCommentE = table.Column<string>(nullable: true),
                    RefrigeratorShelfB = table.Column<int>(nullable: false),
                    RefrigeratorShelfE = table.Column<int>(nullable: false),
                    RefrigeratorShelfCommentB = table.Column<string>(nullable: true),
                    RefrigeratorShelfCommentE = table.Column<string>(nullable: true),
                    RefrigeratorFreezerB = table.Column<int>(nullable: false),
                    RefrigeratorFreezerE = table.Column<int>(nullable: false),
                    RefrigeratorFreezerCommentB = table.Column<string>(nullable: true),
                    RefrigeratorFreezerCommentE = table.Column<string>(nullable: true),
                    DishwasherB = table.Column<int>(nullable: false),
                    DishwasherE = table.Column<int>(nullable: false),
                    DishwasherCommentB = table.Column<string>(nullable: true),
                    DishwasherCommentE = table.Column<string>(nullable: true),
                    StoveB = table.Column<int>(nullable: false),
                    StoveE = table.Column<int>(nullable: false),
                    StoveCommentB = table.Column<string>(nullable: true),
                    StoveCommentE = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitchenCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_KitchenCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivingRoomCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    WallAndTrimeB = table.Column<int>(nullable: false),
                    WallAndTrimeE = table.Column<int>(nullable: false),
                    WallAndTrimsCommentB = table.Column<string>(nullable: true),
                    WallAndTrimsCommentE = table.Column<string>(nullable: true),
                    CeilingsB = table.Column<int>(nullable: false),
                    CeilingsE = table.Column<int>(nullable: false),
                    CeilingsCommentB = table.Column<string>(nullable: true),
                    CeilingsCommentE = table.Column<string>(nullable: true),
                    ClosetsB = table.Column<int>(nullable: false),
                    ClosetsE = table.Column<int>(nullable: false),
                    ClosetsCommentB = table.Column<string>(nullable: true),
                    ClosetsCommentE = table.Column<string>(nullable: true),
                    LightingB = table.Column<int>(nullable: false),
                    LightingE = table.Column<int>(nullable: false),
                    LightingCommentB = table.Column<string>(nullable: true),
                    LightingCommentE = table.Column<string>(nullable: true),
                    WindowsCoveringB = table.Column<int>(nullable: false),
                    WindowsCoveringE = table.Column<int>(nullable: false),
                    WindowsCoveringCommentB = table.Column<int>(nullable: false),
                    WindowsCoveringCommentE = table.Column<int>(nullable: false),
                    ElectricalOutletsB = table.Column<int>(nullable: false),
                    ElectricalOutletsE = table.Column<int>(nullable: false),
                    ElectricalOutletsCommentB = table.Column<string>(nullable: true),
                    ElectricalOutletsCommentE = table.Column<string>(nullable: true),
                    FloorCarpetB = table.Column<int>(nullable: false),
                    FloorCarpetE = table.Column<int>(nullable: false),
                    FloorCarpetCommentB = table.Column<string>(nullable: true),
                    FloorCarpetCommentE = table.Column<string>(nullable: true),
                    AirConditionerB = table.Column<int>(nullable: false),
                    AirConditionerE = table.Column<int>(nullable: false),
                    AirConditionerCommentB = table.Column<string>(nullable: true),
                    AirConditionerCommentE = table.Column<string>(nullable: true),
                    CableTVB = table.Column<int>(nullable: false),
                    CableTVE = table.Column<int>(nullable: false),
                    CableTVCommentB = table.Column<string>(nullable: true),
                    CableTVCommentE = table.Column<string>(nullable: true),
                    FireplaceB = table.Column<int>(nullable: false),
                    FireplaceE = table.Column<int>(nullable: false),
                    FireplaceCommentB = table.Column<string>(nullable: true),
                    FireplaceCommentE = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingRoomCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_LivingRoomCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainBathroomCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    WallAndTrimeB = table.Column<int>(nullable: false),
                    WallAndTrimeE = table.Column<int>(nullable: false),
                    WallAndTrimsCommentB = table.Column<string>(nullable: true),
                    WallAndTrimsCommentE = table.Column<string>(nullable: true),
                    CeilingsB = table.Column<int>(nullable: false),
                    CeilingsE = table.Column<int>(nullable: false),
                    CeilingsCommentB = table.Column<string>(nullable: true),
                    CeilingsCommentE = table.Column<string>(nullable: true),
                    ClosetsB = table.Column<int>(nullable: false),
                    ClosetsE = table.Column<int>(nullable: false),
                    ClosetsCommentB = table.Column<string>(nullable: true),
                    ClosetsCommentE = table.Column<string>(nullable: true),
                    ToiletB = table.Column<int>(nullable: false),
                    ToiletE = table.Column<int>(nullable: false),
                    ToiletCommentB = table.Column<string>(nullable: true),
                    ToiletCommentE = table.Column<string>(nullable: true),
                    DoorB = table.Column<int>(nullable: false),
                    DoorE = table.Column<int>(nullable: false),
                    DoorCommentB = table.Column<string>(nullable: true),
                    DoorCommentE = table.Column<string>(nullable: true),
                    SinkB = table.Column<int>(nullable: false),
                    SinkE = table.Column<int>(nullable: false),
                    SinkCommentB = table.Column<string>(nullable: true),
                    SinkCommentE = table.Column<string>(nullable: true),
                    ShowerTubB = table.Column<int>(nullable: false),
                    ShowerTubE = table.Column<int>(nullable: false),
                    ShowerTubCommentB = table.Column<string>(nullable: true),
                    ShowerTubCommentE = table.Column<string>(nullable: true),
                    LightingB = table.Column<int>(nullable: false),
                    LightingE = table.Column<int>(nullable: false),
                    LightingCommentB = table.Column<string>(nullable: true),
                    LightingCommentE = table.Column<string>(nullable: true),
                    WindowsCoveringB = table.Column<int>(nullable: false),
                    WindowsCoveringE = table.Column<int>(nullable: false),
                    WindowsCoveringCommentB = table.Column<int>(nullable: false),
                    WindowsCoveringCommentE = table.Column<int>(nullable: false),
                    ElectricalOutletsB = table.Column<int>(nullable: false),
                    ElectricalOutletsE = table.Column<int>(nullable: false),
                    ElectricalOutletsCommentB = table.Column<string>(nullable: true),
                    ElectricalOutletsCommentE = table.Column<string>(nullable: true),
                    FloorCarpetB = table.Column<int>(nullable: false),
                    FloorCarpetE = table.Column<int>(nullable: false),
                    FloorCarpetCommentB = table.Column<string>(nullable: true),
                    FloorCarpetCommentE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainBathroomCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_MainBathroomCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterBedroomCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    WallAndTrimeB = table.Column<int>(nullable: false),
                    WallAndTrimeE = table.Column<int>(nullable: false),
                    WallAndTrimsCommentB = table.Column<string>(nullable: true),
                    WallAndTrimsCommentE = table.Column<string>(nullable: true),
                    CeilingsB = table.Column<int>(nullable: false),
                    CeilingsE = table.Column<int>(nullable: false),
                    CeilingsCommentB = table.Column<string>(nullable: true),
                    CeilingsCommentE = table.Column<string>(nullable: true),
                    ClosetsB = table.Column<int>(nullable: false),
                    ClosetsE = table.Column<int>(nullable: false),
                    ClosetsCommentB = table.Column<string>(nullable: true),
                    ClosetsCommentE = table.Column<string>(nullable: true),
                    DoorB = table.Column<int>(nullable: false),
                    DoorE = table.Column<int>(nullable: false),
                    DoorCommentB = table.Column<string>(nullable: true),
                    DoorCommentE = table.Column<string>(nullable: true),
                    LightingB = table.Column<int>(nullable: false),
                    LightingE = table.Column<int>(nullable: false),
                    LightingCommentB = table.Column<string>(nullable: true),
                    LightingCommentE = table.Column<string>(nullable: true),
                    WindowsCoveringB = table.Column<int>(nullable: false),
                    WindowsCoveringE = table.Column<int>(nullable: false),
                    WindowsCoveringCommentB = table.Column<int>(nullable: false),
                    WindowsCoveringCommentE = table.Column<int>(nullable: false),
                    ElectricalOutletsB = table.Column<int>(nullable: false),
                    ElectricalOutletsE = table.Column<int>(nullable: false),
                    ElectricalOutletsCommentB = table.Column<string>(nullable: true),
                    ElectricalOutletsCommentE = table.Column<string>(nullable: true),
                    FloorCarpetB = table.Column<int>(nullable: false),
                    FloorCarpetE = table.Column<int>(nullable: false),
                    FloorCarpetCommentB = table.Column<string>(nullable: true),
                    FloorCarpetCommentE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterBedroomCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_MasterBedroomCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherBedroomCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    WallAndTrimeB = table.Column<int>(nullable: false),
                    WallAndTrimeE = table.Column<int>(nullable: false),
                    WallAndTrimsCommentB = table.Column<string>(nullable: true),
                    WallAndTrimsCommentE = table.Column<string>(nullable: true),
                    CeilingsB = table.Column<int>(nullable: false),
                    CeilingsE = table.Column<int>(nullable: false),
                    CeilingsCommentB = table.Column<string>(nullable: true),
                    CeilingsCommentE = table.Column<string>(nullable: true),
                    ClosetsB = table.Column<int>(nullable: false),
                    ClosetsE = table.Column<int>(nullable: false),
                    ClosetsCommentB = table.Column<string>(nullable: true),
                    ClosetsCommentE = table.Column<string>(nullable: true),
                    DoorB = table.Column<int>(nullable: false),
                    DoorE = table.Column<int>(nullable: false),
                    DoorCommentB = table.Column<string>(nullable: true),
                    DoorCommentE = table.Column<string>(nullable: true),
                    LightingB = table.Column<int>(nullable: false),
                    LightingE = table.Column<int>(nullable: false),
                    LightingCommentB = table.Column<string>(nullable: true),
                    LightingCommentE = table.Column<string>(nullable: true),
                    WindowsCoveringB = table.Column<int>(nullable: false),
                    WindowsCoveringE = table.Column<int>(nullable: false),
                    WindowsCoveringCommentB = table.Column<int>(nullable: false),
                    WindowsCoveringCommentE = table.Column<int>(nullable: false),
                    ElectricalOutletsB = table.Column<int>(nullable: false),
                    ElectricalOutletsE = table.Column<int>(nullable: false),
                    ElectricalOutletsCommentB = table.Column<string>(nullable: true),
                    ElectricalOutletsCommentE = table.Column<string>(nullable: true),
                    FloorCarpetB = table.Column<int>(nullable: false),
                    FloorCarpetE = table.Column<int>(nullable: false),
                    FloorCarpetCommentB = table.Column<string>(nullable: true),
                    FloorCarpetCommentE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherBedroomCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_OtherBedroomCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StairWayHallWayCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    WallAndTrimeB = table.Column<int>(nullable: false),
                    WallAndTrimeE = table.Column<int>(nullable: false),
                    WallAndTrimsCommentB = table.Column<string>(nullable: true),
                    WallAndTrimsCommentE = table.Column<string>(nullable: true),
                    CeilingsB = table.Column<int>(nullable: false),
                    CeilingsE = table.Column<int>(nullable: false),
                    CeilingsCommentB = table.Column<string>(nullable: true),
                    CeilingsCommentE = table.Column<string>(nullable: true),
                    LightingB = table.Column<int>(nullable: false),
                    LightingE = table.Column<int>(nullable: false),
                    LightingCommentB = table.Column<string>(nullable: true),
                    LightingCommentE = table.Column<string>(nullable: true),
                    WindowsCoveringB = table.Column<int>(nullable: false),
                    WindowsCoveringE = table.Column<int>(nullable: false),
                    WindowsCoveringCommentB = table.Column<int>(nullable: false),
                    WindowsCoveringCommentE = table.Column<int>(nullable: false),
                    ElectricalOutletsB = table.Column<int>(nullable: false),
                    ElectricalOutletsE = table.Column<int>(nullable: false),
                    ElectricalOutletsCommentB = table.Column<string>(nullable: true),
                    ElectricalOutletsCommentE = table.Column<string>(nullable: true),
                    ClosetsB = table.Column<int>(nullable: false),
                    ClosetsE = table.Column<int>(nullable: false),
                    ClosetsCommentB = table.Column<string>(nullable: true),
                    ClosetsCommentE = table.Column<string>(nullable: true),
                    TreadsAndLandingsB = table.Column<int>(nullable: false),
                    TreadsAndLandingsE = table.Column<int>(nullable: false),
                    TreadsAndLandingsCommentB = table.Column<string>(nullable: true),
                    TreadsAndLandingsCommentE = table.Column<string>(nullable: true),
                    RailingB = table.Column<int>(nullable: false),
                    RailingE = table.Column<int>(nullable: false),
                    RailingCommentB = table.Column<string>(nullable: true),
                    RailingCommentE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StairWayHallWayCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_StairWayHallWayCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    ConditionB = table.Column<int>(nullable: false),
                    ConditionE = table.Column<int>(nullable: false),
                    ConditionCommentB = table.Column<string>(nullable: true),
                    ConditionCommentE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_StorageCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtilityRoomCondition",
                columns: table => new
                {
                    PropertyInspectionId = table.Column<int>(nullable: false),
                    ElectricalOutletsB = table.Column<int>(nullable: false),
                    ElectricalOutletsE = table.Column<int>(nullable: false),
                    ElectricalOutletsCommentB = table.Column<string>(nullable: true),
                    ElectricalOutletsCommentE = table.Column<string>(nullable: true),
                    WasherDryerB = table.Column<int>(nullable: false),
                    WasherDryerE = table.Column<int>(nullable: false),
                    WasherDryerCommentB = table.Column<string>(nullable: true),
                    WasherDryerCommentE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityRoomCondition", x => x.PropertyInspectionId);
                    table.ForeignKey(
                        name: "FK_UtilityRoomCondition_Inspection_PropertyInspectionId",
                        column: x => x.PropertyInspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_LeaseId",
                table: "Inspection",
                column: "LeaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasementCondition");

            migrationBuilder.DropTable(
                name: "DinningRoomCondition");

            migrationBuilder.DropTable(
                name: "EntryCondition");

            migrationBuilder.DropTable(
                name: "ExteriorCondition");

            migrationBuilder.DropTable(
                name: "GarageParkingAreaCondition");

            migrationBuilder.DropTable(
                name: "KeyAndControlCondition");

            migrationBuilder.DropTable(
                name: "KitchenCondition");

            migrationBuilder.DropTable(
                name: "LivingRoomCondition");

            migrationBuilder.DropTable(
                name: "MainBathroomCondition");

            migrationBuilder.DropTable(
                name: "MasterBedroomCondition");

            migrationBuilder.DropTable(
                name: "OtherBedroomCondition");

            migrationBuilder.DropTable(
                name: "StairWayHallWayCondition");

            migrationBuilder.DropTable(
                name: "StorageCondition");

            migrationBuilder.DropTable(
                name: "UtilityRoomCondition");

            migrationBuilder.DropTable(
                name: "Inspection");
        }
    }
}
