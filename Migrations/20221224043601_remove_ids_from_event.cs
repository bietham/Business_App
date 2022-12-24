using Microsoft.EntityFrameworkCore.Migrations;

namespace Task3.Migrations
{
    public partial class remove_ids_from_event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "MastermindId1",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "MastermindId",
                table: "Events",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliverymanId",
                table: "Events",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_DeliverymanId",
                table: "Events",
                column: "DeliverymanId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_MastermindId",
                table: "Events",
                column: "MastermindId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_DeliverymanId",
                table: "Events",
                column: "DeliverymanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_MastermindId",
                table: "Events",
                column: "MastermindId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_DeliverymanId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_MastermindId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_DeliverymanId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_MastermindId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "MastermindId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliverymanId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliverymanId1",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MastermindId1",
                table: "Events",
                type: "nvarchar(450)",
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
    }
}
