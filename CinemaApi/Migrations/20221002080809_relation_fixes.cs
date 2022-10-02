using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    public partial class relation_fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Addresses_AddressId",
                table: "CinemaHalls");

            migrationBuilder.DropIndex(
                name: "IX_CinemaHalls_AddressId",
                table: "CinemaHalls");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "CinemaHalls");

            migrationBuilder.RenameColumn(
                name: "Seats",
                table: "SeetReservings",
                newName: "Seat");

            migrationBuilder.RenameColumn(
                name: "Rows",
                table: "SeetReservings",
                newName: "Row");


            migrationBuilder.CreateTable(
                name: "AddressesHasHalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CinemaHallId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressesHasHalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressesHasHalls_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressesHasHalls_CinemaHalls_CinemaHallId",
                        column: x => x.CinemaHallId,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressesHasHalls_AddressId",
                table: "AddressesHasHalls",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressesHasHalls_CinemaHallId",
                table: "AddressesHasHalls",
                column: "CinemaHallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressesHasHalls");

            migrationBuilder.RenameColumn(
                name: "Seat",
                table: "SeetReservings",
                newName: "Seats");

            migrationBuilder.RenameColumn(
                name: "Row",
                table: "SeetReservings",
                newName: "Rows");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "CinemaHalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_AddressId",
                table: "CinemaHalls",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaHalls_Addresses_AddressId",
                table: "CinemaHalls",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
