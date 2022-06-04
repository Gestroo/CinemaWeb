using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CinemaLibrary.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Client_ClientID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Film_Genre_GenreID",
                table: "Film");

            migrationBuilder.DropForeignKey(
                name: "FK_HallRow_CinemaHall_CinemaHallID",
                table: "HallRow");

            migrationBuilder.DropForeignKey(
                name: "FK_HallSeat_HallRow_HallRowID",
                table: "HallSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_Personal_Role_RoleID",
                table: "Personal");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Client_ClientID",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Booking_BookingID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Ticket_TicketID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_CinemaHall_CinemaHallHallNumber",
                table: "Seance");

            migrationBuilder.DropForeignKey(
                name: "FK_Seance_Film_FilmID",
                table: "Seance");

            migrationBuilder.DropForeignKey(
                name: "FK_SeanceBoughtSeats_HallSeat_BoughtSeatsID",
                table: "SeanceBoughtSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_SeanceBoughtSeats_Seance_BoughtSeancesID",
                table: "SeanceBoughtSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_SeanceReservedSeats_HallSeat_ReservedSeatsID",
                table: "SeanceReservedSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_SeanceReservedSeats_Seance_ReservedSeancesID",
                table: "SeanceReservedSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_HallRow_RowID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_HallSeat_SeatID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Personal_PersonalID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Seance_SeanceID",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "CinemaHallTime");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seance",
                table: "Seance");

            migrationBuilder.DropIndex(
                name: "IX_Seance_CinemaHallHallNumber",
                table: "Seance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personal",
                table: "Personal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HallSeat",
                table: "HallSeat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HallRow",
                table: "HallRow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Film",
                table: "Film");

            migrationBuilder.DropIndex(
                name: "IX_Film_GenreID",
                table: "Film");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaHall",
                table: "CinemaHall");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CinemaHallHallNumber",
                table: "Seance");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "Film");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "ticket");

            migrationBuilder.RenameTable(
                name: "Seance",
                newName: "seance");

            migrationBuilder.RenameTable(
                name: "Personal",
                newName: "personal");

            migrationBuilder.RenameTable(
                name: "HallSeat",
                newName: "hallseat");

            migrationBuilder.RenameTable(
                name: "HallRow",
                newName: "hallrow");

            migrationBuilder.RenameTable(
                name: "Film",
                newName: "film");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "client");

            migrationBuilder.RenameTable(
                name: "CinemaHall",
                newName: "cinemahall");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "booking");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ticket",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "ticket",
                newName: "total_price");

            migrationBuilder.RenameColumn(
                name: "SeatID",
                table: "ticket",
                newName: "seat_id");

            migrationBuilder.RenameColumn(
                name: "SeanceID",
                table: "ticket",
                newName: "seance_id");

            migrationBuilder.RenameColumn(
                name: "RowID",
                table: "ticket",
                newName: "row_id");

            migrationBuilder.RenameColumn(
                name: "PersonalID",
                table: "ticket",
                newName: "personal_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_SeatID",
                table: "ticket",
                newName: "IX_ticket_seat_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_SeanceID",
                table: "ticket",
                newName: "IX_ticket_seance_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_RowID",
                table: "ticket",
                newName: "IX_ticket_row_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_PersonalID",
                table: "ticket",
                newName: "IX_ticket_personal_id");

            migrationBuilder.RenameColumn(
                name: "SeanceDate",
                table: "seance",
                newName: "seancedate");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "seance",
                newName: "cost");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "seance",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FilmID",
                table: "seance",
                newName: "film_id");

            migrationBuilder.RenameIndex(
                name: "IX_Seance_FilmID",
                table: "seance",
                newName: "IX_seance_film_id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "personal",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "personal",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "personal",
                newName: "middlename");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "personal",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "personal",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "personal",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "personal",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "personal",
                newName: "role_id");

            migrationBuilder.RenameIndex(
                name: "IX_Personal_PhoneNumber",
                table: "personal",
                newName: "IX_personal_phonenumber");

            migrationBuilder.RenameIndex(
                name: "IX_Personal_RoleID",
                table: "personal",
                newName: "IX_personal_role_id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "hallseat",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SeatNumber",
                table: "hallseat",
                newName: "seat_number");

            migrationBuilder.RenameColumn(
                name: "HallRowID",
                table: "hallseat",
                newName: "hallrow_id");

            migrationBuilder.RenameIndex(
                name: "IX_HallSeat_HallRowID",
                table: "hallseat",
                newName: "IX_hallseat_hallrow_id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "hallrow",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RowNumber",
                table: "hallrow",
                newName: "row_number");

            migrationBuilder.RenameColumn(
                name: "CinemaHallID",
                table: "hallrow",
                newName: "cinemahall_id");

            migrationBuilder.RenameIndex(
                name: "IX_HallRow_CinemaHallID",
                table: "hallrow",
                newName: "IX_hallrow_cinemahall_id");

            migrationBuilder.RenameColumn(
                name: "Restriction",
                table: "film",
                newName: "restriction");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "film",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "film",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "film",
                newName: "datestart");

            migrationBuilder.RenameColumn(
                name: "DateFinish",
                table: "film",
                newName: "datefinish");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "film",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "film",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "client",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "client",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "client",
                newName: "middlename");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "client",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "client",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "client",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "client",
                newName: "birthdate");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "client",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Client_PhoneNumber",
                table: "client",
                newName: "IX_client_phonenumber");

            migrationBuilder.RenameColumn(
                name: "HallName",
                table: "cinemahall",
                newName: "hallname");

            migrationBuilder.RenameColumn(
                name: "HallNumber",
                table: "cinemahall",
                newName: "hallnumber");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "booking",
                newName: "datetime");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "booking",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "booking",
                newName: "client_id");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_ClientID",
                table: "booking",
                newName: "IX_booking_client_id");

            migrationBuilder.AlterColumn<int>(
                name: "seat_id",
                table: "ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "row_id",
                table: "ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "personal_id",
                table: "ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "film_id",
                table: "seance",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cinemahall_id",
                table: "seance",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ticket",
                table: "ticket",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_seance",
                table: "seance",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_personal",
                table: "personal",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hallseat",
                table: "hallseat",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hallrow",
                table: "hallrow",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_film",
                table: "film",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_client",
                table: "client",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cinemahall",
                table: "cinemahall",
                column: "hallnumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_booking",
                table: "booking",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_seance_cinemahall_id",
                table: "seance",
                column: "cinemahall_id");

            migrationBuilder.CreateIndex(
                name: "IX_film_id",
                table: "film",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_client_client_id",
                table: "booking",
                column: "client_id",
                principalTable: "client",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_film_Genre_id",
                table: "film",
                column: "id",
                principalTable: "Genre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hallrow_cinemahall_cinemahall_id",
                table: "hallrow",
                column: "cinemahall_id",
                principalTable: "cinemahall",
                principalColumn: "hallnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hallseat_hallrow_hallrow_id",
                table: "hallseat",
                column: "hallrow_id",
                principalTable: "hallrow",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personal_Role_role_id",
                table: "personal",
                column: "role_id",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_client_ClientID",
                table: "RefreshTokens",
                column: "ClientID",
                principalTable: "client",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_booking_BookingID",
                table: "Reservation",
                column: "BookingID",
                principalTable: "booking",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ticket_TicketID",
                table: "Reservation",
                column: "TicketID",
                principalTable: "ticket",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_seance_cinemahall_cinemahall_id",
                table: "seance",
                column: "cinemahall_id",
                principalTable: "cinemahall",
                principalColumn: "hallnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_seance_film_film_id",
                table: "seance",
                column: "film_id",
                principalTable: "film",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeanceBoughtSeats_hallseat_BoughtSeatsID",
                table: "SeanceBoughtSeats",
                column: "BoughtSeatsID",
                principalTable: "hallseat",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeanceBoughtSeats_seance_BoughtSeancesID",
                table: "SeanceBoughtSeats",
                column: "BoughtSeancesID",
                principalTable: "seance",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeanceReservedSeats_hallseat_ReservedSeatsID",
                table: "SeanceReservedSeats",
                column: "ReservedSeatsID",
                principalTable: "hallseat",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeanceReservedSeats_seance_ReservedSeancesID",
                table: "SeanceReservedSeats",
                column: "ReservedSeancesID",
                principalTable: "seance",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_hallrow_row_id",
                table: "ticket",
                column: "row_id",
                principalTable: "hallrow",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_hallseat_seat_id",
                table: "ticket",
                column: "seat_id",
                principalTable: "hallseat",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_personal_personal_id",
                table: "ticket",
                column: "personal_id",
                principalTable: "personal",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_seance_seance_id",
                table: "ticket",
                column: "seance_id",
                principalTable: "seance",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_client_client_id",
                table: "booking");

            migrationBuilder.DropForeignKey(
                name: "FK_film_Genre_id",
                table: "film");

            migrationBuilder.DropForeignKey(
                name: "FK_hallrow_cinemahall_cinemahall_id",
                table: "hallrow");

            migrationBuilder.DropForeignKey(
                name: "FK_hallseat_hallrow_hallrow_id",
                table: "hallseat");

            migrationBuilder.DropForeignKey(
                name: "FK_personal_Role_role_id",
                table: "personal");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_client_ClientID",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_booking_BookingID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ticket_TicketID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_seance_cinemahall_cinemahall_id",
                table: "seance");

            migrationBuilder.DropForeignKey(
                name: "FK_seance_film_film_id",
                table: "seance");

            migrationBuilder.DropForeignKey(
                name: "FK_SeanceBoughtSeats_hallseat_BoughtSeatsID",
                table: "SeanceBoughtSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_SeanceBoughtSeats_seance_BoughtSeancesID",
                table: "SeanceBoughtSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_SeanceReservedSeats_hallseat_ReservedSeatsID",
                table: "SeanceReservedSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_SeanceReservedSeats_seance_ReservedSeancesID",
                table: "SeanceReservedSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_hallrow_row_id",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_hallseat_seat_id",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_personal_personal_id",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_seance_seance_id",
                table: "ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ticket",
                table: "ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_seance",
                table: "seance");

            migrationBuilder.DropIndex(
                name: "IX_seance_cinemahall_id",
                table: "seance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_personal",
                table: "personal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hallseat",
                table: "hallseat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hallrow",
                table: "hallrow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_film",
                table: "film");

            migrationBuilder.DropIndex(
                name: "IX_film_id",
                table: "film");

            migrationBuilder.DropPrimaryKey(
                name: "PK_client",
                table: "client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cinemahall",
                table: "cinemahall");

            migrationBuilder.DropPrimaryKey(
                name: "PK_booking",
                table: "booking");

            migrationBuilder.DropColumn(
                name: "cinemahall_id",
                table: "seance");

            migrationBuilder.RenameTable(
                name: "ticket",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "seance",
                newName: "Seance");

            migrationBuilder.RenameTable(
                name: "personal",
                newName: "Personal");

            migrationBuilder.RenameTable(
                name: "hallseat",
                newName: "HallSeat");

            migrationBuilder.RenameTable(
                name: "hallrow",
                newName: "HallRow");

            migrationBuilder.RenameTable(
                name: "film",
                newName: "Film");

            migrationBuilder.RenameTable(
                name: "client",
                newName: "Client");

            migrationBuilder.RenameTable(
                name: "cinemahall",
                newName: "CinemaHall");

            migrationBuilder.RenameTable(
                name: "booking",
                newName: "Booking");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Ticket",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "total_price",
                table: "Ticket",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "seat_id",
                table: "Ticket",
                newName: "SeatID");

            migrationBuilder.RenameColumn(
                name: "seance_id",
                table: "Ticket",
                newName: "SeanceID");

            migrationBuilder.RenameColumn(
                name: "row_id",
                table: "Ticket",
                newName: "RowID");

            migrationBuilder.RenameColumn(
                name: "personal_id",
                table: "Ticket",
                newName: "PersonalID");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_seat_id",
                table: "Ticket",
                newName: "IX_Ticket_SeatID");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_seance_id",
                table: "Ticket",
                newName: "IX_Ticket_SeanceID");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_row_id",
                table: "Ticket",
                newName: "IX_Ticket_RowID");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_personal_id",
                table: "Ticket",
                newName: "IX_Ticket_PersonalID");

            migrationBuilder.RenameColumn(
                name: "seancedate",
                table: "Seance",
                newName: "SeanceDate");

            migrationBuilder.RenameColumn(
                name: "cost",
                table: "Seance",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Seance",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "film_id",
                table: "Seance",
                newName: "FilmID");

            migrationBuilder.RenameIndex(
                name: "IX_seance_film_id",
                table: "Seance",
                newName: "IX_Seance_FilmID");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "Personal",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Personal",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "middlename",
                table: "Personal",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "Personal",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Personal",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Personal",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Personal",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "Personal",
                newName: "RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_personal_phonenumber",
                table: "Personal",
                newName: "IX_Personal_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_personal_role_id",
                table: "Personal",
                newName: "IX_Personal_RoleID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "HallSeat",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "seat_number",
                table: "HallSeat",
                newName: "SeatNumber");

            migrationBuilder.RenameColumn(
                name: "hallrow_id",
                table: "HallSeat",
                newName: "HallRowID");

            migrationBuilder.RenameIndex(
                name: "IX_hallseat_hallrow_id",
                table: "HallSeat",
                newName: "IX_HallSeat_HallRowID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "HallRow",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "row_number",
                table: "HallRow",
                newName: "RowNumber");

            migrationBuilder.RenameColumn(
                name: "cinemahall_id",
                table: "HallRow",
                newName: "CinemaHallID");

            migrationBuilder.RenameIndex(
                name: "IX_hallrow_cinemahall_id",
                table: "HallRow",
                newName: "IX_HallRow_CinemaHallID");

            migrationBuilder.RenameColumn(
                name: "restriction",
                table: "Film",
                newName: "Restriction");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Film",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Film",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "datestart",
                table: "Film",
                newName: "DateStart");

            migrationBuilder.RenameColumn(
                name: "datefinish",
                table: "Film",
                newName: "DateFinish");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Film",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Film",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "Client",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Client",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "middlename",
                table: "Client",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Client",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Client",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Client",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "birthdate",
                table: "Client",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Client",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_client_phonenumber",
                table: "Client",
                newName: "IX_Client_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "hallname",
                table: "CinemaHall",
                newName: "HallName");

            migrationBuilder.RenameColumn(
                name: "hallnumber",
                table: "CinemaHall",
                newName: "HallNumber");

            migrationBuilder.RenameColumn(
                name: "datetime",
                table: "Booking",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Booking",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "client_id",
                table: "Booking",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_booking_client_id",
                table: "Booking",
                newName: "IX_Booking_ClientID");

            migrationBuilder.AlterColumn<int>(
                name: "SeatID",
                table: "Ticket",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RowID",
                table: "Ticket",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalID",
                table: "Ticket",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "FilmID",
                table: "Seance",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CinemaHallHallNumber",
                table: "Seance",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "Film",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seance",
                table: "Seance",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personal",
                table: "Personal",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HallSeat",
                table: "HallSeat",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HallRow",
                table: "HallRow",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Film",
                table: "Film",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaHall",
                table: "CinemaHall",
                column: "HallNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeanceTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CinemaHallTime",
                columns: table => new
                {
                    HallsHallNumber = table.Column<int>(type: "integer", nullable: false),
                    SeanceTimesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHallTime", x => new { x.HallsHallNumber, x.SeanceTimesID });
                    table.ForeignKey(
                        name: "FK_CinemaHallTime_CinemaHall_HallsHallNumber",
                        column: x => x.HallsHallNumber,
                        principalTable: "CinemaHall",
                        principalColumn: "HallNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaHallTime_Time_SeanceTimesID",
                        column: x => x.SeanceTimesID,
                        principalTable: "Time",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "ID", "SeanceTime" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(1, 1, 1, 17, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(1, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(1, 1, 1, 8, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(1, 1, 1, 21, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(1, 1, 1, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(1, 1, 1, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(1, 1, 1, 9, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(1, 1, 1, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(1, 1, 1, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(1, 1, 1, 19, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(1, 1, 1, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(1, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(1, 1, 1, 16, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(1, 1, 1, 13, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(1, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(1, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 23, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 11, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(1, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(1, 1, 1, 22, 20, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seance_CinemaHallHallNumber",
                table: "Seance",
                column: "CinemaHallHallNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Film_GenreID",
                table: "Film",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHallTime_SeanceTimesID",
                table: "CinemaHallTime",
                column: "SeanceTimesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Client_ClientID",
                table: "Booking",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Genre_GenreID",
                table: "Film",
                column: "GenreID",
                principalTable: "Genre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HallRow_CinemaHall_CinemaHallID",
                table: "HallRow",
                column: "CinemaHallID",
                principalTable: "CinemaHall",
                principalColumn: "HallNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HallSeat_HallRow_HallRowID",
                table: "HallSeat",
                column: "HallRowID",
                principalTable: "HallRow",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_Role_RoleID",
                table: "Personal",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Client_ClientID",
                table: "RefreshTokens",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Booking_BookingID",
                table: "Reservation",
                column: "BookingID",
                principalTable: "Booking",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Ticket_TicketID",
                table: "Reservation",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_CinemaHall_CinemaHallHallNumber",
                table: "Seance",
                column: "CinemaHallHallNumber",
                principalTable: "CinemaHall",
                principalColumn: "HallNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_Film_FilmID",
                table: "Seance",
                column: "FilmID",
                principalTable: "Film",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeanceBoughtSeats_HallSeat_BoughtSeatsID",
                table: "SeanceBoughtSeats",
                column: "BoughtSeatsID",
                principalTable: "HallSeat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeanceBoughtSeats_Seance_BoughtSeancesID",
                table: "SeanceBoughtSeats",
                column: "BoughtSeancesID",
                principalTable: "Seance",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeanceReservedSeats_HallSeat_ReservedSeatsID",
                table: "SeanceReservedSeats",
                column: "ReservedSeatsID",
                principalTable: "HallSeat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeanceReservedSeats_Seance_ReservedSeancesID",
                table: "SeanceReservedSeats",
                column: "ReservedSeancesID",
                principalTable: "Seance",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_HallRow_RowID",
                table: "Ticket",
                column: "RowID",
                principalTable: "HallRow",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_HallSeat_SeatID",
                table: "Ticket",
                column: "SeatID",
                principalTable: "HallSeat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Personal_PersonalID",
                table: "Ticket",
                column: "PersonalID",
                principalTable: "Personal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Seance_SeanceID",
                table: "Ticket",
                column: "SeanceID",
                principalTable: "Seance",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
