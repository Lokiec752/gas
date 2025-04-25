using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gas.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReedingsSeedFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PrimaryReading", "SecondaryReading" },
                values: new object[] { 703, 299 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Readings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PrimaryReading", "SecondaryReading" },
                values: new object[] { 299, 703 });
        }
    }
}
