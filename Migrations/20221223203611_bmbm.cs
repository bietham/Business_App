using Microsoft.EntityFrameworkCore.Migrations;

namespace Task3.Migrations
{
    public partial class bmbm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InventoryType_InventoryTypeId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InventoryTypeId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InventoryTypeId",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Inventories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_TypeId",
                table: "Inventories",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_InventoryType_TypeId",
                table: "Inventories",
                column: "TypeId",
                principalTable: "InventoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InventoryType_TypeId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_TypeId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryTypeId",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryTypeId",
                table: "Inventories",
                column: "InventoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_InventoryType_InventoryTypeId",
                table: "Inventories",
                column: "InventoryTypeId",
                principalTable: "InventoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
