using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    public partial class name_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScreenPlay_MoviePerformings_MoviePerformingId",
                table: "ScreenPlay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScreenPlay",
                table: "ScreenPlay");

            migrationBuilder.RenameTable(
                name: "ScreenPlay",
                newName: "ScreenPlays");

            migrationBuilder.RenameIndex(
                name: "IX_ScreenPlay_MoviePerformingId",
                table: "ScreenPlays",
                newName: "IX_ScreenPlays_MoviePerformingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScreenPlays",
                table: "ScreenPlays",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenPlays_MoviePerformings_MoviePerformingId",
                table: "ScreenPlays",
                column: "MoviePerformingId",
                principalTable: "MoviePerformings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScreenPlays_MoviePerformings_MoviePerformingId",
                table: "ScreenPlays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScreenPlays",
                table: "ScreenPlays");

            migrationBuilder.RenameTable(
                name: "ScreenPlays",
                newName: "ScreenPlay");

            migrationBuilder.RenameIndex(
                name: "IX_ScreenPlays_MoviePerformingId",
                table: "ScreenPlay",
                newName: "IX_ScreenPlay_MoviePerformingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScreenPlay",
                table: "ScreenPlay",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenPlay_MoviePerformings_MoviePerformingId",
                table: "ScreenPlay",
                column: "MoviePerformingId",
                principalTable: "MoviePerformings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
