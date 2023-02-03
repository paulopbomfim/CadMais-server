using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadMais.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDatabaseTimeFormatToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 12, 46, 51, 514, DateTimeKind.Utc).AddTicks(8240),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 12, 46, 51, 514, DateTimeKind.Utc).AddTicks(7976),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 2, 3, 12, 46, 51, 514, DateTimeKind.Utc).AddTicks(8240));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 2, 3, 12, 46, 51, 514, DateTimeKind.Utc).AddTicks(7976));
        }
    }
}
