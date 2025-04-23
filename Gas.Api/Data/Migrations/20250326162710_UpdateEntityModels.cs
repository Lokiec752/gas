using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gas.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Users_UserId",
                table: "Readings");

            migrationBuilder.DropIndex(
                name: "IX_Readings_UserId",
                table: "Readings");

            migrationBuilder.DeleteData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Readings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Readings",
                newName: "SecondaryReading");

            migrationBuilder.RenameColumn(
                name: "Reading",
                table: "Readings",
                newName: "PrimaryReading");

            migrationBuilder.AddColumn<string>(
                name: "MeterReadingType",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1,
                column: "SecondaryReading",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "PrimaryReading", "SecondaryReading" },
                values: new object[] { new DateOnly(2025, 1, 1), 299, 703 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "MeterReadingType",
                value: "Primary");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "MeterReadingType",
                value: "Secondary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeterReadingType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "SecondaryReading",
                table: "Readings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PrimaryReading",
                table: "Readings",
                newName: "Reading");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Readings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Type", "UserId" },
                values: new object[] { "Primary", 1 });

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Reading", "Type", "UserId" },
                values: new object[] { new DateOnly(2024, 12, 1), 0, "Primary", 2 });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "Date", "Reading", "Type", "UserId" },
                values: new object[,]
                {
                    { 3, new DateOnly(2025, 1, 1), 703, "Primary", 1 },
                    { 4, new DateOnly(2025, 1, 1), 299, "Secondary", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Readings_UserId",
                table: "Readings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Users_UserId",
                table: "Readings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
