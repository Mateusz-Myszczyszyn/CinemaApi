using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    public partial class UsersIssueDataAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceiveDate",
                table: "UsersIssues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 20, 59, 5, 346, DateTimeKind.Utc).AddTicks(3816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 20, 44, 30, 543, DateTimeKind.Utc).AddTicks(7132));

            migrationBuilder.AddColumn<string>(
                name: "IssueName",
                table: "UsersIssues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueName",
                table: "UsersIssues");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceiveDate",
                table: "UsersIssues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 20, 44, 30, 543, DateTimeKind.Utc).AddTicks(7132),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 20, 59, 5, 346, DateTimeKind.Utc).AddTicks(3816));
        }
    }
}
