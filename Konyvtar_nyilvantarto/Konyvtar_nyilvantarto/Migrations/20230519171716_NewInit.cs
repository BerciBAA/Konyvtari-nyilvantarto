using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Konyvtar_nyilvantarto.Migrations
{
    public partial class NewInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfPublication = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryMembers",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryMembers", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingData",
                columns: table => new
                {
                    BorrowingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowingDataLibraryMembersFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowingDataBookEntityFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RetrievalLimitTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingData", x => x.BorrowingId);
                    table.ForeignKey(
                        name: "FK_BorrowingData_Books_BorrowingDataBookEntityFK",
                        column: x => x.BorrowingDataBookEntityFK,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowingData_LibraryMembers_BorrowingDataLibraryMembersFK",
                        column: x => x.BorrowingDataLibraryMembersFK,
                        principalTable: "LibraryMembers",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingData_BorrowingDataBookEntityFK",
                table: "BorrowingData",
                column: "BorrowingDataBookEntityFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingData_BorrowingDataLibraryMembersFK",
                table: "BorrowingData",
                column: "BorrowingDataLibraryMembersFK",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowingData");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "LibraryMembers");
        }
    }
}
