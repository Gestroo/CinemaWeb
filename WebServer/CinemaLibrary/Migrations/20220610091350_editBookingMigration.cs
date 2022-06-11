using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CinemaLibrary.Migrations
{
    public partial class editBookingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "TicketID",
                table: "booking",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isBought",
                table: "booking",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_booking_TicketID",
                table: "booking",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_ticket_TicketID",
                table: "booking",
                column: "TicketID",
                principalTable: "ticket",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_ticket_TicketID",
                table: "booking");

            migrationBuilder.DropIndex(
                name: "IX_booking_TicketID",
                table: "booking");

            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "booking");

            migrationBuilder.DropColumn(
                name: "isBought",
                table: "booking");

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketID = table.Column<int>(type: "integer", nullable: false),
                    BookingID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservation_booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "booking",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Reservation_ticket_TicketID",
                        column: x => x.TicketID,
                        principalTable: "ticket",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BookingID",
                table: "Reservation",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_TicketID",
                table: "Reservation",
                column: "TicketID");
        }
    }
}
