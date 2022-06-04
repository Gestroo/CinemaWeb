using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaLibrary.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "Film",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Client",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Client",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "text", nullable: false),
                    ClientID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_GenreID",
                table: "Film",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_ClientID",
                table: "RefreshTokens",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Genre_GenreID",
                table: "Film",
                column: "GenreID",
                principalTable: "Genre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Genre_GenreID",
                table: "Film");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_Film_GenreID",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Client");

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                columns: table => new
                {
                    FilmsID = table.Column<int>(type: "integer", nullable: false),
                    GenreID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => new { x.FilmsID, x.GenreID });
                    table.ForeignKey(
                        name: "FK_FilmGenre_Film_FilmsID",
                        column: x => x.FilmsID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenre_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_GenreID",
                table: "FilmGenre",
                column: "GenreID");
        }
    }
}
