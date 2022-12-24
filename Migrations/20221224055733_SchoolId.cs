using Microsoft.EntityFrameworkCore.Migrations;

namespace Task3.Migrations
{
    public partial class SchoolId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_AspNetUsers_UserId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_UserId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Schools");

            migrationBuilder.AddColumn<string>(
                name: "StorekeeperId",
                table: "Schools",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_StorekeeperId",
                table: "Schools",
                column: "StorekeeperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_AspNetUsers_StorekeeperId",
                table: "Schools",
                column: "StorekeeperId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_AspNetUsers_StorekeeperId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_StorekeeperId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "StorekeeperId",
                table: "Schools");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Schools",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_UserId",
                table: "Schools",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_AspNetUsers_UserId",
                table: "Schools",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
