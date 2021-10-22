using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsApp.Data.Migrations
{
    public partial class PlaceOrganizer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "placeType",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Organizer");

            migrationBuilder.DropColumn(
                name: "address",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "city",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "province",
                table: "Event");

            migrationBuilder.AddColumn<bool>(
                name: "confirmed",
                table: "Place",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "confirmed",
                table: "Organizer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirmed",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "confirmed",
                table: "Organizer");

            migrationBuilder.AddColumn<string>(
                name: "placeType",
                table: "Place",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Organizer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "province",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
