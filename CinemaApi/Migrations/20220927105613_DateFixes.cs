using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    public partial class DateFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Premiere",
                table: "Movies",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Premiere",
                table: "Movies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);
        }
    }
}
