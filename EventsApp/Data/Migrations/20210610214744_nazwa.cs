using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsApp.Data.Migrations
{
    public partial class nazwa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Event_EventId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Event_EventId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinion_Event_EventId",
                table: "Opinion");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Event_EventId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_EventId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Opinion_EventId",
                table: "Opinion");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_EventId",
                table: "Favourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Album_EventId",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Opinion");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Album");

            migrationBuilder.AddColumn<int>(
                name: "MainEventId",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainEventId",
                table: "Opinion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainEventId",
                table: "Favourites",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainEventId",
                table: "Event",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MainEventId",
                table: "Album",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "MainEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_MainEventId",
                table: "Ticket",
                column: "MainEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinion_MainEventId",
                table: "Opinion",
                column: "MainEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_MainEventId",
                table: "Favourites",
                column: "MainEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_MainEventId",
                table: "Album",
                column: "MainEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Event_MainEventId",
                table: "Album",
                column: "MainEventId",
                principalTable: "Event",
                principalColumn: "MainEventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Event_MainEventId",
                table: "Favourites",
                column: "MainEventId",
                principalTable: "Event",
                principalColumn: "MainEventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinion_Event_MainEventId",
                table: "Opinion",
                column: "MainEventId",
                principalTable: "Event",
                principalColumn: "MainEventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Event_MainEventId",
                table: "Ticket",
                column: "MainEventId",
                principalTable: "Event",
                principalColumn: "MainEventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Event_MainEventId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Event_MainEventId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinion_Event_MainEventId",
                table: "Opinion");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Event_MainEventId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_MainEventId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Opinion_MainEventId",
                table: "Opinion");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_MainEventId",
                table: "Favourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Album_MainEventId",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "MainEventId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "MainEventId",
                table: "Opinion");

            migrationBuilder.DropColumn(
                name: "MainEventId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "MainEventId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "MainEventId",
                table: "Album");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Opinion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Favourites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Album",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EventId",
                table: "Ticket",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinion_EventId",
                table: "Opinion",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_EventId",
                table: "Favourites",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_EventId",
                table: "Album",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Event_EventId",
                table: "Album",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Event_EventId",
                table: "Favourites",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinion_Event_EventId",
                table: "Opinion",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Event_EventId",
                table: "Ticket",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
