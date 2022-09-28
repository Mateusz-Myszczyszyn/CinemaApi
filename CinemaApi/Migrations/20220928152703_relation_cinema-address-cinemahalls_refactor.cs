using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    public partial class relation_cinemaaddresscinemahalls_refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Cinemas_CinemaId",
                table: "CinemaHalls");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "CinemaHalls",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaHalls_CinemaId",
                table: "CinemaHalls",
                newName: "IX_CinemaHalls_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_Addresses_AddressId",
                table: "CinemaHalls",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Addresses_AddressId",
                table: "CinemaHalls");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "CinemaHalls",
                newName: "CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_CinemaHalls_AddressId",
                table: "CinemaHalls",
                newName: "IX_CinemaHalls_CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_Cinemas_CinemaId",
                table: "CinemaHalls",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
