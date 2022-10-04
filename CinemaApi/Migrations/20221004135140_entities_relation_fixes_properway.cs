using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    public partial class entities_relation_fixes_properway : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeatReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Payed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HallSeatId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ScreenPlayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatReservations_HallSeats_HallSeatId",
                        column: x => x.HallSeatId,
                        principalTable: "HallSeats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeatReservations_ScreenPlays_ScreenPlayId",
                        column: x => x.ScreenPlayId,
                        principalTable: "ScreenPlays",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeatReservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatReservations_HallSeatId",
                table: "SeatReservations",
                column: "HallSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatReservations_ScreenPlayId",
                table: "SeatReservations",
                column: "ScreenPlayId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatReservations_UserId",
                table: "SeatReservations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatReservations");
        }
    }
}
