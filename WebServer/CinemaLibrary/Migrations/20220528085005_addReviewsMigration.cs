using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CinemaLibrary.Migrations
{
    public partial class addReviewsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "poster",
                table: "film",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilmID = table.Column<int>(type: "integer", nullable: true),
                    ClientID = table.Column<int>(type: "integer", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Review_client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "client",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Review_film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "film",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ClientID",
                table: "Review",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_FilmID",
                table: "Review",
                column: "FilmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropColumn(
                name: "poster",
                table: "film");
        }
    }
}
