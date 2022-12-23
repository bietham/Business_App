using Microsoft.EntityFrameworkCore.Migrations;

namespace Task3.Migrations
{
    public partial class please : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryTypeId",
                table: "Inventories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InventoryType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryType", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InventoryType_InventoryTypeId",
                table: "Inventories");

            migrationBuilder.DropTable(
                name: "InventoryType");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InventoryTypeId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InventoryTypeId",
                table: "Inventories");
        }
    }
}
