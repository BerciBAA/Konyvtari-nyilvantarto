using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Konyvtar_nyilvantarto.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "borrowingData",
                columns: table => new
                {
                    BorrowingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibraryMembersMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrowingData", x => x.BorrowingId);
                    table.ForeignKey(
                        name: "FK_borrowingData_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                  
                });

            migrationBuilder.CreateIndex(
                name: "IX_borrowingData_BookId",
                table: "borrowingData",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_borrowingData_LibraryMembersMemberId",
                table: "borrowingData",
                column: "LibraryMembersMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "borrowingData");

        }
    }
}
