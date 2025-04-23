using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gas.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GasAmount = table.Column<float>(type: "REAL", nullable: false),
                    Subscription = table.Column<float>(type: "REAL", nullable: false),
                    ConstDistribution = table.Column<float>(type: "REAL", nullable: false),
                    VariableDistribution = table.Column<float>(type: "REAL", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrimaryReading = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondaryReading = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MeterReadingType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    PreviousReadingId = table.Column<int>(type: "INTEGER", nullable: true),
                    CurrentReadingId = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalAmount = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBills_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBills_Readings_CurrentReadingId",
                        column: x => x.CurrentReadingId,
                        principalTable: "Readings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserBills_Readings_PreviousReadingId",
                        column: x => x.PreviousReadingId,
                        principalTable: "Readings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserBills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "Date", "PrimaryReading", "SecondaryReading" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 12, 1), 0, 0 },
                    { 2, new DateOnly(2025, 1, 1), 299, 703 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "MeterReadingType", "Name" },
                values: new object[,]
                {
                    { 1, "Primary", "22E" },
                    { 2, "Secondary", "22H" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBills_CurrentReadingId",
                table: "UserBills",
                column: "CurrentReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBills_InvoiceId",
                table: "UserBills",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBills_PreviousReadingId",
                table: "UserBills",
                column: "PreviousReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBills_UserId",
                table: "UserBills",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBills");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Readings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
