using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    public partial class entities_relation_fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressesHasHalls");

            migrationBuilder.DropTable(
                name: "CinemaHallHallSeats");

            migrationBuilder.DropTable(
                name: "SeatReservations");

            migrationBuilder.AddColumn<string>(
                name: "Cast",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Seat",
                table: "HallSeats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Row",
                table: "HallSeats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CinemaHallId",
                table: "HallSeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "CinemaHalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HallSeats_CinemaHallId",
                table: "HallSeats",
                column: "CinemaHallId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_HallSeats_CinemaHalls_CinemaHallId",
                table: "HallSeats",
                column: "CinemaHallId",
                principalTable: "CinemaHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaHalls_Addresses_AddressId",
                table: "CinemaHalls");

            migrationBuilder.DropForeignKey(
                name: "FK_HallSeats_CinemaHalls_CinemaHallId",
                table: "HallSeats");

            migrationBuilder.DropIndex(
                name: "IX_HallSeats_CinemaHallId",
                table: "HallSeats");

            migrationBuilder.DropIndex(
                name: "IX_CinemaHalls_AddressId",
                table: "CinemaHalls");

            migrationBuilder.DropColumn(
                name: "Cast",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CinemaHallId",
                table: "HallSeats");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "CinemaHalls");

            migrationBuilder.AlterColumn<string>(
                name: "Seat",
                table: "HallSeats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Row",
                table: "HallSeats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateTable(
                name: "SeatReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Seat = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_AddressesHasHalls_AddressId",
                table: "AddressesHasHalls",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressesHasHalls_CinemaHallId",
                table: "AddressesHasHalls",
                column: "CinemaHallId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHallHallSeats_HallSeatsId",
                table: "CinemaHallHallSeats",
                column: "HallSeatsId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatReservations_UserId",
                table: "SeatReservations",
                column: "UserId");
        }
    }
}
