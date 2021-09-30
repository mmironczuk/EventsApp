using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsApp.Data.Migrations
{
    public partial class poprawaUsera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "login",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "type",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "login",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
