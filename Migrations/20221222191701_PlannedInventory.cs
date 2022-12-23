using Microsoft.EntityFrameworkCore.Migrations;

namespace Task3.Migrations
{
    public partial class PlannedInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PlannedInventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "PlannedInventories",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PlannedInventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
