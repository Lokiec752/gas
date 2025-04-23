using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gas.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Initial_Readings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Reading" },
                values: new object[] { new DateOnly(2024, 12, 1), 0 });

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Reading", "Type" },
                values: new object[] { new DateOnly(2024, 12, 1), 0, "Primary" });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "Date", "Reading", "Type", "UserId" },
                values: new object[,]
                {
                    { 3, new DateOnly(2025, 1, 1), 703, "Primary", 1 },
                    { 4, new DateOnly(2025, 1, 1), 299, "Secondary", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Reading" },
                values: new object[] { new DateOnly(2025, 1, 1), 703 });

            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Reading", "Type" },
                values: new object[] { new DateOnly(2025, 1, 1), 299, "Secondary" });
        }
    }
}
