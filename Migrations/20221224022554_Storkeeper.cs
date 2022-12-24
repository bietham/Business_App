using Microsoft.EntityFrameworkCore.Migrations;

namespace Task3.Migrations
{
    public partial class Storkeeper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliverymanId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_DeliverymanId",
                table: "Events",
                column: "DeliverymanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_DeliverymanId",
                table: "Events",
                column: "DeliverymanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_DeliverymanId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_DeliverymanId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DeliverymanId",
                table: "Events");
        }
    }
}
