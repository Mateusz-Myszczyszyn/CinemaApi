using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    public partial class entity_name_fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeetReservings");

            migrationBuilder.CreateTable(
                name: "HallSeats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallSeats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Seat = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatReservations", x => new { x.Id, x.Row, x.Seat });
                    table.ForeignKey(
                        name: "FK_SeatReservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CinemaHallHallSeats",
                columns: table => new
                {
                    CinemaHallsId = table.Column<int>(type: "int", nullable: false),
                    HallSeatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHallHallSeats", x => new { x.CinemaHallsId, x.HallSeatsId });
                    table.ForeignKey(
                        name: "FK_CinemaHallHallSeats_CinemaHalls_CinemaHallsId",
                        column: x => x.CinemaHallsId,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaHallHallSeats_HallSeats_HallSeatsId",
                        column: x => x.HallSeatsId,
                        principalTable: "HallSeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHallHallSeats_HallSeatsId",
                table: "CinemaHallHallSeats",
                column: "HallSeatsId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatReservations_UserId",
                table: "SeatReservations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaHallHallSeats");

            migrationBuilder.DropTable(
                name: "SeatReservations");

            migrationBuilder.DropTable(
                name: "HallSeats");

            migrationBuilder.CreateTable(
                name: "SeetReservings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Seat = table.Column<int>(type: "int", nullable: false),
                    CinemaHallId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeetReservings", x => new { x.Id, x.Row, x.Seat });
                    table.ForeignKey(
                        name: "FK_SeetReservings_CinemaHalls_CinemaHallId",
                        column: x => x.CinemaHallId,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeetReservings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeetReservings_CinemaHallId",
                table: "SeetReservings",
                column: "CinemaHallId");

            migrationBuilder.CreateIndex(
                name: "IX_SeetReservings_UserId",
                table: "SeetReservings",
                column: "UserId");
        }
    }
}
