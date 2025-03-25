using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gas.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGasMeterReadingEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "Date", "Reading", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 1, 1), 703, "Primary", 1 },
                    { 2, new DateOnly(2025, 1, 1), 299, "Secondary", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
