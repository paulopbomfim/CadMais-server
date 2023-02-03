using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadMais.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTimeStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 12, 46, 51, 514, DateTimeKind.Utc).AddTicks(7976));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 12, 46, 51, 514, DateTimeKind.Utc).AddTicks(8240));
        }
    }
}
