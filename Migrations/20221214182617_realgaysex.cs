using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task3.Migrations
{
    public partial class realgaysex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    MeasurementUnit = table.Column<string>(nullable: true),
                    Amount = table.Column<float>(nullable: false),
                    Rented = table.Column<float>(nullable: false),
                    Missing = table.Column<float>(nullable: false),
                    Analogous = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: true),
                    SchoolId = table.Column<int>(nullable: true),
                    Approval = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentRequests_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RentRequests_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlannedInventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: true),
                    RentRequestId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    MeasurementUnit = table.Column<string>(nullable: true),
                    Amount = table.Column<float>(nullable: false),
                    Rented = table.Column<float>(nullable: false),
                    Missing = table.Column<float>(nullable: false),
                    Analogous = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedInventories_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlannedInventories_RentRequests_RentRequestId",
                        column: x => x.RentRequestId,
                        principalTable: "RentRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequestedInventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentRequestId = table.Column<int>(nullable: true),
                    InventoryId = table.Column<int>(nullable: true),
                    Amount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestedInventory_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestedInventory_RentRequests_RentRequestId",
                        column: x => x.RentRequestId,
                        principalTable: "RentRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickupTime = table.Column<DateTime>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    DeliverymanId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    RentRequestId = table.Column<int>(nullable: true),
                    UnloadRequest_RentRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_DeliverymanId",
                        column: x => x.DeliverymanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_RentRequests_RentRequestId",
                        column: x => x.RentRequestId,
                        principalTable: "RentRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_RentRequests_UnloadRequest_RentRequestId",
                        column: x => x.UnloadRequest_RentRequestId,
                        principalTable: "RentRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AllocatedInventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: true),
                    PlannedInventoryId = table.Column<int>(nullable: false),
                    RentRequestId = table.Column<int>(nullable: false),
                    InventoryId = table.Column<int>(nullable: true),
                    ReturnRequestId = table.Column<int>(nullable: true),
                    MeasurementUnit = table.Column<string>(nullable: true),
                    Amount = table.Column<float>(nullable: false),
                    AmountUsed = table.Column<float>(nullable: false),
                    Missing = table.Column<float>(nullable: false),
                    Analogous = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocatedInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllocatedInventories_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AllocatedInventories_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AllocatedInventories_PlannedInventories_PlannedInventoryId",
                        column: x => x.PlannedInventoryId,
                        principalTable: "PlannedInventories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AllocatedInventories_RentRequests_RentRequestId",
                        column: x => x.RentRequestId,
                        principalTable: "RentRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AllocatedInventories_Requests_ReturnRequestId",
                        column: x => x.ReturnRequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllocatedInventories_EventId",
                table: "AllocatedInventories",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocatedInventories_InventoryId",
                table: "AllocatedInventories",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocatedInventories_PlannedInventoryId",
                table: "AllocatedInventories",
                column: "PlannedInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocatedInventories_RentRequestId",
                table: "AllocatedInventories",
                column: "RentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocatedInventories_ReturnRequestId",
                table: "AllocatedInventories",
                column: "ReturnRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SchoolId",
                table: "Inventories",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedInventories_EventId",
                table: "PlannedInventories",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedInventories_RentRequestId",
                table: "PlannedInventories",
                column: "RentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RentRequests_EventId",
                table: "RentRequests",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_RentRequests_SchoolId",
                table: "RentRequests",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedInventory_InventoryId",
                table: "RequestedInventory",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedInventory_RentRequestId",
                table: "RequestedInventory",
                column: "RentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeliverymanId",
                table: "Requests",
                column: "DeliverymanId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RentRequestId",
                table: "Requests",
                column: "RentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UnloadRequest_RentRequestId",
                table: "Requests",
                column: "UnloadRequest_RentRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllocatedInventories");

            migrationBuilder.DropTable(
                name: "RequestedInventory");

            migrationBuilder.DropTable(
                name: "PlannedInventories");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "RentRequests");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
