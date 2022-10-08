using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    public partial class scrplay_entity_columnadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DigitalView",
                table: "ScreenPlays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "2D");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DigitalView",
                table: "ScreenPlays");
        }
    }
}
