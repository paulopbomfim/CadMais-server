using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadMais.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDatabaseTimeFormatToGetDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 2, 3, 5, 30, 20, 272, DateTimeKind.Utc).AddTicks(5718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 2, 3, 5, 30, 20, 272, DateTimeKind.Utc).AddTicks(5376));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 5, 30, 20, 272, DateTimeKind.Utc).AddTicks(5718),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 5, 30, 20, 272, DateTimeKind.Utc).AddTicks(5376),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
