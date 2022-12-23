using Microsoft.EntityFrameworkCore.Migrations;

namespace Task3.Migrations
{
    public partial class crazylol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InventoryType_TypeId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestedInventory_Inventories_InventoryId",
                table: "RequestedInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryType",
                table: "InventoryType");

            migrationBuilder.RenameTable(
                name: "InventoryType",
                newName: "InventoryTypes");

            migrationBuilder.AddColumn<int>(
                name: "InventoryTypeId",
                table: "RequestedInventory",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryTypes",
                table: "InventoryTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestedInventory_InventoryTypeId",
                table: "RequestedInventory",
                column: "InventoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_InventoryTypes_TypeId",
                table: "Inventories",
                column: "TypeId",
                principalTable: "InventoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestedInventory_Inventories_InventoryId",
                table: "RequestedInventory",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestedInventory_InventoryTypes_InventoryTypeId",
                table: "RequestedInventory",
                column: "InventoryTypeId",
                principalTable: "InventoryTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InventoryTypes_TypeId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestedInventory_Inventories_InventoryId",
                table: "RequestedInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestedInventory_InventoryTypes_InventoryTypeId",
                table: "RequestedInventory");

            migrationBuilder.DropIndex(
                name: "IX_RequestedInventory_InventoryTypeId",
                table: "RequestedInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryTypes",
                table: "InventoryTypes");

            migrationBuilder.DropColumn(
                name: "InventoryTypeId",
                table: "RequestedInventory");

            migrationBuilder.RenameTable(
                name: "InventoryTypes",
                newName: "InventoryType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryType",
                table: "InventoryType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_InventoryType_TypeId",
                table: "Inventories",
                column: "TypeId",
                principalTable: "InventoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestedInventory_Inventories_InventoryId",
                table: "RequestedInventory",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id");
        }
    }
}
