using Microsoft.EntityFrameworkCore.Migrations;

namespace Task3.Migrations
{
    public partial class plannedinvtotype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedInventories_Inventories_InventoryId",
                table: "PlannedInventories");

            migrationBuilder.DropIndex(
                name: "IX_PlannedInventories_InventoryId",
                table: "PlannedInventories");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "PlannedInventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryTypeId",
                table: "PlannedInventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlannedInventories_InventoryTypeId",
                table: "PlannedInventories",
                column: "InventoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedInventories_InventoryTypes_InventoryTypeId",
                table: "PlannedInventories",
                column: "InventoryTypeId",
                principalTable: "InventoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedInventories_InventoryTypes_InventoryTypeId",
                table: "PlannedInventories");

            migrationBuilder.DropIndex(
                name: "IX_PlannedInventories_InventoryTypeId",
                table: "PlannedInventories");

            migrationBuilder.DropColumn(
                name: "InventoryTypeId",
                table: "PlannedInventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "PlannedInventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlannedInventories_InventoryId",
                table: "PlannedInventories",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedInventories_Inventories_InventoryId",
                table: "PlannedInventories",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
