using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Konyvtar_nyilvantarto.Migrations
{
    public partial class updateBorrowingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RentalTime",
                table: "BorrowingData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RetrievalLimitTime",
                table: "BorrowingData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalTime",
                table: "BorrowingData");

            migrationBuilder.DropColumn(
                name: "RetrievalLimitTime",
                table: "BorrowingData");
        }
    }
}
