using Microsoft.EntityFrameworkCore.Migrations;

namespace Task3.Migrations
{
    public partial class rentRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Analogous",
                table: "PlannedInventories");

            migrationBuilder.DropColumn(
                name: "MeasurementUnit",
                table: "PlannedInventories");

            migrationBuilder.DropColumn(
                name: "Missing",
                table: "PlannedInventories");

            migrationBuilder.DropColumn(
                name: "Rented",
                table: "PlannedInventories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Analogous",
                table: "PlannedInventories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnit",
                table: "PlannedInventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Missing",
                table: "PlannedInventories",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Rented",
                table: "PlannedInventories",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
