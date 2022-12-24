using Microsoft.EntityFrameworkCore.Migrations;

namespace Task3.Migrations
{
    public partial class EventUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_DeliverymanId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_UserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_DeliverymanId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_UserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "DeliverymanId",
                table: "Events",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliverymanId1",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MastermindId",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MastermindId1",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_DeliverymanId1",
                table: "Events",
                column: "DeliverymanId1");

            migrationBuilder.CreateIndex(
                name: "IX_Events_MastermindId1",
                table: "Events",
                column: "MastermindId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_DeliverymanId1",
                table: "Events",
                column: "DeliverymanId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_MastermindId1",
                table: "Events",
                column: "MastermindId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_DeliverymanId1",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_MastermindId1",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_DeliverymanId1",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_MastermindId1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DeliverymanId1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MastermindId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MastermindId1",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "DeliverymanId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_DeliverymanId",
                table: "Events",
                column: "DeliverymanId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_DeliverymanId",
                table: "Events",
                column: "DeliverymanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_UserId",
                table: "Events",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
