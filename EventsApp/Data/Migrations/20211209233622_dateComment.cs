using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsApp.Data.Migrations
{
    public partial class dateComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Opinion");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Favourites");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Opinion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Opinion");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Opinion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Favourites",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
