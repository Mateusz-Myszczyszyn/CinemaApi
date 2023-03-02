using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    public partial class datedisable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceiveDate",
                table: "UsersIssues",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 21, 31, 9, 791, DateTimeKind.Utc).AddTicks(7424));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceiveDate",
                table: "UsersIssues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 21, 31, 9, 791, DateTimeKind.Utc).AddTicks(7424),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
