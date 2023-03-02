using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    public partial class DataFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceiveDate",
                table: "UsersIssues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 21, 31, 9, 791, DateTimeKind.Utc).AddTicks(7424),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 20, 59, 5, 346, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "UsersIssues",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceiveDate",
                table: "UsersIssues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 20, 59, 5, 346, DateTimeKind.Utc).AddTicks(3816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 21, 31, 9, 791, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "UsersIssues",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
