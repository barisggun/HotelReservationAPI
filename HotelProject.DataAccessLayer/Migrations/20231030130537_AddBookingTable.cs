using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_About",
                table: "About");

            migrationBuilder.RenameTable(
                name: "About",
                newName: "Abouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts",
                column: "AboutID");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdultCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts");

            migrationBuilder.RenameTable(
                name: "Abouts",
                newName: "About");

            migrationBuilder.AddPrimaryKey(
                name: "PK_About",
                table: "About",
                column: "AboutID");
        }
    }
}
