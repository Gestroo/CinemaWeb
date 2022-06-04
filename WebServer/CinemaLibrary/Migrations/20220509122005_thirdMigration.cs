using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaLibrary.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_Genre_id",
                table: "film");

            migrationBuilder.DropForeignKey(
                name: "FK_personal_Role_role_id",
                table: "personal");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ticket_TicketID",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "role");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "role",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PersonalRole",
                table: "role",
                newName: "personal_role");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "genre",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "genre",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "genre",
                newName: "id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "seancedate",
                table: "seance",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<int>(
                name: "TicketID",
                table: "Reservation",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "datestart",
                table: "film",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datefinish",
                table: "film",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthdate",
                table: "client",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datetime",
                table: "booking",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role",
                table: "role",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genre",
                table: "genre",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_film_genre_id",
                table: "film",
                column: "id",
                principalTable: "genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personal_role_role_id",
                table: "personal",
                column: "role_id",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ticket_TicketID",
                table: "Reservation",
                column: "TicketID",
                principalTable: "ticket",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_genre_id",
                table: "film");

            migrationBuilder.DropForeignKey(
                name: "FK_personal_role_role_id",
                table: "personal");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ticket_TicketID",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role",
                table: "role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genre",
                table: "genre");

            migrationBuilder.RenameTable(
                name: "role",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "genre",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Role",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "personal_role",
                table: "Role",
                newName: "PersonalRole");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Genre",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Genre",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Genre",
                newName: "ID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "seancedate",
                table: "seance",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "TicketID",
                table: "Reservation",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datestart",
                table: "film",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datefinish",
                table: "film",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthdate",
                table: "client",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datetime",
                table: "booking",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_film_Genre_id",
                table: "film",
                column: "id",
                principalTable: "Genre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personal_Role_role_id",
                table: "personal",
                column: "role_id",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ticket_TicketID",
                table: "Reservation",
                column: "TicketID",
                principalTable: "ticket",
                principalColumn: "id");
        }
    }
}
